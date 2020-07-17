using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.Extensions;
using Investec.OpenBanking.RestClient.Interfaces;
using Investec.OpenBanking.RestClient.Options;
using Investec.OpenBanking.RestClient.RequestModels;
using Investec.OpenBanking.RestClient.ResponseModels;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;
using Microsoft.Extensions.Options;
using Refit;

namespace Investec.OpenBanking.RestClient.Services
{
    /// <summary>
    ///     REST client for interacting with Investec's Open Banking aligned Open APIs
    /// </summary>
    public class InvestecOpenBankingClient : IInvestecOpenBankingClient
    {
        private readonly IClassificationService _classificationService;
        private readonly HttpClient _httpClient;
        private readonly InvestecOpenBankingClientOptions _options;

        public InvestecOpenBankingClient(IOptions<InvestecOpenBankingClientOptions> optionsAccessor,
                                         IClassificationService classificationService)
        {
            if (optionsAccessor == null)
            {
                throw new ArgumentNullException(nameof(optionsAccessor));
            }

            _options = optionsAccessor.Value;
            _classificationService = classificationService;
            _httpClient = new HttpClient(
                              new AuthenticatedHttpClientHandler(GetAccessToken))
                          {
                              Timeout = TimeSpan.FromMinutes(1),
                              BaseAddress = new Uri(InvestecOpenBankingClientConstants.ApiUrl)
                          };

            _identityEndpoint = RestService.For<IIdentity>(InvestecOpenBankingClientConstants.BaseUrl);
            _accountsEndpoint = RestService.For<IAccounts>(_httpClient);
        }

        /// <summary>
        ///     /identity/
        /// </summary>
        private IIdentity _identityEndpoint { get; }

        /// <summary>
        ///     /za/pb/v1/accounts
        /// </summary>
        private IAccounts _accountsEndpoint { get; }

        /// <summary>
        ///     POST /identity/v2/oauth2/token
        ///     Obtain an access token
        /// </summary>
        /// <returns>
        ///     Access Token Response   <see cref="Investec.OpenBanking.RestClient.ResponseModels.AccessTokenResponseModel" />
        /// </returns>
        public async Task<AccessTokenResponseModel> GetAccessToken()
        {
            try
            {
                var authHeader =
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_options.ClientId}:{_options.ClientSecret}"));
                var response = await _identityEndpoint.GetAccessToken($"Basic {authHeader}",
                    (Dictionary<string, object>) new AccessTokenRequestModel(_options.Scopes)
                        .ToDictionary());
                return response;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return null;
        }

        /// <summary>
        ///     POST /za/pb/v1/accounts
        ///     Obtain a list of accounts.
        /// </summary>
        /// <returns>
        ///     Accounts Response Model
        ///     <see cref="Investec.OpenBanking.RestClient.ResponseModels.Accounts.AccountsResponseModel" />
        /// </returns>
        public async Task<BaseResponseModel<AccountsResponseModel>> GetAccounts()
        {
            try
            {
                return await _accountsEndpoint.GetAccounts();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return new BaseResponseModel<AccountsResponseModel>(new AccountsResponseModel());
        }

        /// <summary>
        ///     POST /za/pb/v1/accounts{accountId}/transactions
        ///     Obtain a specified account's transactions.
        /// </summary>
        /// <param name="accountId">Account identifier</param>
        /// <returns>
        ///     Account Transactions Response
        ///     <see cref="Investec.OpenBanking.RestClient.ResponseModels.Accounts.AccountTransactionsResponseModel" />
        /// </returns>
        public async Task<BaseResponseModel<AccountTransactionsResponseModel>> GetAccountTransactions(string accountId)
        {
            try
            {
                var transactions = await _accountsEndpoint.GetTransactions(accountId);
                if (_options.EnableTransactionClassification)
                {
                    transactions.data.transactions = await _classificationService.ClassifyTransactions(transactions.data.transactions);
                }

                return transactions;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return new BaseResponseModel<AccountTransactionsResponseModel>(new AccountTransactionsResponseModel());
        }

        /// <summary>
        ///     POST /za/pb/v1/accounts{accountId}/balance
        ///     Obtain a specified account's balance.
        /// </summary>
        /// <param name="accountId">Account identifier</param>
        /// <returns>
        ///     Account Balance Response
        ///     <see cref="Investec.OpenBanking.RestClient.ResponseModels.Accounts.AccountBalanceResponseModel" />
        /// </returns>
        public async Task<BaseResponseModel<AccountBalanceResponseModel>> GetAccountBalance(string accountId)
        {
            try
            {
                return await _accountsEndpoint.GetBalance(accountId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return new BaseResponseModel<AccountBalanceResponseModel>(new AccountBalanceResponseModel());
        }
    }
}