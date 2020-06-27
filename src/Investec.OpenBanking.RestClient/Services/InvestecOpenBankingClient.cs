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
    public class InvestecOpenBankingClient : IInvestecOpenBankingClient
    {
        private readonly HttpClient _httpClient;
        private readonly InvestecOpenBankingClientOptions _options;

        public InvestecOpenBankingClient(IOptions<InvestecOpenBankingClientOptions> optionsAccessor)
        {
            if (optionsAccessor == null)
            {
                throw new ArgumentNullException(nameof(optionsAccessor));
            }

            _options = optionsAccessor.Value;
            _httpClient = new HttpClient(
                              new AuthenticatedHttpClientHandler(GetAccessToken))
                          {
                              Timeout = TimeSpan.FromMinutes(1),
                              BaseAddress = new Uri(InvestecOpenBankingClientConstants.ApiUrl)
                          };

            _identityEndpoint = RestService.For<IIdentity>(InvestecOpenBankingClientConstants.BaseUrl);
            _accountsEndpoint = RestService.For<IAccounts>(_httpClient);
        }

        private IIdentity _identityEndpoint { get; }
        private IAccounts _accountsEndpoint { get; }

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

        public async Task<BaseResponseModel<AccountTransactionsResponseModel>> GetAccountTransactions(string accountId)
        {
            try
            {
                return await _accountsEndpoint.GetTransactions(accountId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return new BaseResponseModel<AccountTransactionsResponseModel>(new AccountTransactionsResponseModel());
        }

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