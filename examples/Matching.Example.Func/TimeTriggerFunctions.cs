using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.Extensions;
using Investec.OpenBanking.RestClient.Interfaces;
using Investec.OpenBanking.RestClient.ResponseModels;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;
using Microsoft.Azure.WebJobs;
using MicrosoftGraph.RestClient.Interfaces;
using Newtonsoft.Json;

namespace Matching.Example.Func
{
    public class TimeTriggerFunctions
    {
        private readonly HttpClient _httpClient;
        private readonly IInvestecOpenBankingClient _investecOpenBankingClient;
        private readonly IMicrosoftGraphClient _microsoftGraphClient;
        private readonly string _sharePointGroupId;

        public TimeTriggerFunctions(IHttpClientFactory httpClientFactory, IMicrosoftGraphClient microsoftGraphClient,
                                    IInvestecOpenBankingClient
                                        investecOpenBankingClient)
        {
            _httpClient = httpClientFactory.CreateClient();
            _microsoftGraphClient = microsoftGraphClient;
            _investecOpenBankingClient = investecOpenBankingClient;
            _sharePointGroupId = Environment.GetEnvironmentVariable("SharePointGroupId");
        }

        /// <summary>
        ///     Get a hash to match card transactions to OpenAPI transactions
        /// </summary>
        /// <param name="date">YYYY-MM of transaction eg. 2020-07</param>
        /// <param name="merchantDescriptor">eg. Uber Eats</param>
        /// <param name="centAmount">eg. 18070</param>
        /// <returns>String Guid created from a MD5 hash</returns>
        private string CreateTransactionMatchingHash(string date, string merchantDescriptor, string centAmount)
        {
            var merchantParts = merchantDescriptor.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return $"{date} {merchantParts.FirstOrDefault()} {centAmount}".ToUpper().ToMd5Guid().ToString();
        }

        // Crontab 0 */1 * * * * => Run every minute
        [FunctionName("MatchInvestecTransactions")]
        public async Task MatchInvestecTransactions([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            try
            {
                var accountsRes = await _investecOpenBankingClient.GetAccounts();
                var privateBankAccount = accountsRes.data.accounts
                                                    .FirstOrDefault(f =>
                                                        f.product == AccountsResponseModel.AccountProducts.PrivateBankAccount);
                if (privateBankAccount != null)
                {
                    // Get existing API transactions
                    var apiTransactionsFolderContents = await _microsoftGraphClient.GetDriveFolderContents(_sharePointGroupId,
                        "transactions");
                    if (apiTransactionsFolderContents != null)
                    {
                        var transactionsRes = await _investecOpenBankingClient.GetAccountTransactions(privateBankAccount.accountId);
                        foreach (var apiTx in transactionsRes.data.transactions)
                        {
                            // Model made up of only constant values from the transaction
                            var notification = new NotificationModel(apiTx);
                            // Serialise model to JSON
                            var apiTxJson = JsonConvert.SerializeObject(notification);
                            // MD5 hash the JSON then covert hash to a Guid
                            var apiTxId = apiTxJson.ToMd5Guid().ToString();
                            // Check if transaction has already been stored
                            var existingFile = apiTransactionsFolderContents.value.FirstOrDefault(f => string.Equals(f.name,
                                $"{apiTxId}.json",
                                StringComparison
                                    .InvariantCultureIgnoreCase));
                            if (existingFile == null)
                            {
                                await _microsoftGraphClient.UploadJsonFileToDrive(_sharePointGroupId, "transactions", apiTxId, apiTxJson);
                                var txMatchingHash = CreateTransactionMatchingHash(notification.postingDate.Substring(0, 7),
                                    notification.description, notification.amount.ToString("0.00").RemoveNonDigits());

                                // Go back 7 days if needed to find a match
                                for (var i = 0; i < 8; i++)
                                {
                                    var apiTxDt = DateTime.Parse(notification.postingDate).AddDays(i * -1);
                                    var cardTxPath = $@"{privateBankAccount.accountNumber}\{apiTxDt.Year}/{apiTxDt.Month:D2}/{apiTxDt
                                        .Day:D2}/{notification.cardNumber}";
                                    try
                                    {
                                        // Get existing Card transactions
                                        var cardTransactionsFolderContents =
                                            await _microsoftGraphClient.GetDriveFolderContents(_sharePointGroupId, cardTxPath);
                                        if (cardTransactionsFolderContents != null)
                                        {
                                            foreach (var tx in cardTransactionsFolderContents.value)
                                            {
                                                var txJson = await _httpClient.GetStringAsync(tx.DownloadUrl);
                                                var cardTx = JsonConvert.DeserializeObject<AfterTransactionModel>(txJson);
                                                var cardTxHash = CreateTransactionMatchingHash(
                                                    cardTx.dateTime.GetValueOrDefault().ToString("yyyy-MM"),
                                                    cardTx.merchant?.name, cardTx.centsAmount.ToString());

                                                if (string.Equals(txMatchingHash, cardTxHash,
                                                    StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    var matchedTxJson = JsonConvert.SerializeObject(new
                                                                                                    {
                                                                                                        ApiTransaction = notification,
                                                                                                        CardTransaction = cardTx
                                                                                                    });
                                                    var matchedTxId = matchedTxJson.ToMd5Guid().ToString();
                                                    await _microsoftGraphClient.UploadJsonFileToDrive(_sharePointGroupId,
                                                        "matched-transactions",
                                                        matchedTxId, matchedTxJson);
                                                    i = 8;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}