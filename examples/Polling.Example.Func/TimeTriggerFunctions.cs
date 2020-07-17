using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.Extensions;
using Investec.OpenBanking.RestClient.Interfaces;
using Investec.OpenBanking.RestClient.ResponseModels;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace Polling.Example.Func
{
    public class TimeTriggerFunctions
    {
        private readonly IInvestecOpenBankingClient _investecOpenBankingClient;

        public TimeTriggerFunctions(IInvestecOpenBankingClient investecOpenBankingClient) =>
            _investecOpenBankingClient = investecOpenBankingClient;

        // Crontab 0 */1 * * * * => Run every minute
        [FunctionName("PollInvestecBankAccount")]
        public async Task PollInvestecBankAccount([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            try
            {
                // Get existing transactions from database, filesystem etc.
                var existingTransactionsInDataStore = new List<Guid>();

                if (existingTransactionsInDataStore.Any())
                {
                    // Get all accounts from Investec API
                    var accounts = await _investecOpenBankingClient.GetAccounts();
                    // Get the accountId for the first account that is a Private Bank Account
                    var accountId = accounts.data.accounts
                                            .FirstOrDefault(f =>
                                                f.product == AccountsResponseModel.AccountProducts.PrivateBankAccount)
                                            ?.accountId;
                    // Get all transactions for the last 180 days from Investec API
                    var latestTransactions = await _investecOpenBankingClient.GetAccountTransactions(accountId);
                    foreach (var transaction in latestTransactions.data.transactions)
                    {
                        // Model made up of only constant values from the transaction
                        var notification = new NotificationModel(transaction);
                        // Serialise model to JSON
                        var json = JsonConvert.SerializeObject(notification);
                        // MD5 hash the JSON then covert hash to a Guid
                        var id = json.ToMd5Guid();

                        // Check if transaction has already been stored
                        var existingTx = existingTransactionsInDataStore.FirstOrDefault(pk => pk == id);
                        if (existingTx == null || existingTx == Guid.Empty)
                        {
                            // Add new transaction to data store
                            // Send notification
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