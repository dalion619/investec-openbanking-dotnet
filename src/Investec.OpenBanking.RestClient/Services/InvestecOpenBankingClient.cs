using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.Extensions;
using Investec.OpenBanking.RestClient.Interfaces;
using Investec.OpenBanking.RestClient.Options;
using Investec.OpenBanking.RestClient.RequestModels;
using Investec.OpenBanking.RestClient.ResponseModels;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;
using Investec.OpenBanking.RestClient.ResponseModels.Cards;
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
        private readonly HttpClient _pbHttpClient;
        private readonly HttpClient _cardHttpClient;
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
            _pbHttpClient = new HttpClient(
                new AuthenticatedHttpClientHandler(GetAccessToken))
            {
                Timeout = TimeSpan.FromMinutes(1),
                BaseAddress = new Uri(InvestecOpenBankingClientConstants.PrivateBankingApiUrl)
            };
            _cardHttpClient = new HttpClient(
                new AuthenticatedHttpClientHandler(GetAccessToken))
            {
                Timeout = TimeSpan.FromMinutes(1),
                BaseAddress = new Uri(InvestecOpenBankingClientConstants.ApiUrl)
            };

            _identityEndpoint = RestService.For<IIdentity>(InvestecOpenBankingClientConstants.BaseUrl);
            _accountsEndpoint = RestService.For<IAccounts>(_pbHttpClient);
            _cardsEndpoint = RestService.For<ICards>(_cardHttpClient);
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
        ///     /za/v1/cards
        /// </summary>
        private ICards _cardsEndpoint { get; }

        /// <summary>
        ///     POST /identity/v2/oauth2/token
        ///     Obtain an access token
        /// </summary>
        /// <returns>
        ///     Access Token Response   <see cref="Investec.OpenBanking.RestClient.ResponseModels.AccessTokenResponseModel" />
        /// </returns>
        public async Task<AccessTokenResponseModel> GetAccessToken()
        {
            var authHeader =
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_options.ClientId}:{_options.ClientSecret}"));
            var response = await _identityEndpoint.GetAccessToken($"Basic {authHeader}", _options.ApiKey,
                (Dictionary<string, object>) new AccessTokenRequestModel(_options.Scopes)
                    .ToDictionary());
            return response;
        }
        
        /// <summary>
        ///     GET /za/v1/cards
        ///     Obtain a list of cards.
        /// </summary>
        /// <returns>
        ///     Cards Response Model
        ///     <see cref="Investec.OpenBanking.RestClient.ResponseModels.Cards.CardsResponseModel" />
        /// </returns>
        public async Task<BaseResponseModel<CardsResponseModel>> GetCards() => await _cardsEndpoint.GetCards();
        
        /// <summary>
        ///     GET /za/v1/cards/{cardKey}
        ///     Obtain a a specified card.
        /// </summary>
        /// <returns>
        ///     Card Response Model
        ///     <see cref="Investec.OpenBanking.RestClient.ResponseModels.Cards.CardResponseModel" />
        /// </returns>
        public async Task<BaseResponseModel<CardResponseModel>> GetCard(string cardKey) => await _cardsEndpoint.GetCard(cardKey);

        /// <summary>
        ///     GET /za/pb/v1/accounts
        ///     Obtain a list of accounts.
        /// </summary>
        /// <returns>
        ///     Accounts Response Model
        ///     <see cref="Investec.OpenBanking.RestClient.ResponseModels.Accounts.AccountsResponseModel" />
        /// </returns>
        public async Task<BaseResponseModel<AccountsResponseModel>> GetAccounts() => await _accountsEndpoint.GetAccounts();

        /// <summary>
        ///     GET /za/pb/v1/accounts{accountId}/transactions
        ///     Obtain a specified account's transactions.
        /// </summary>
        /// <param name="accountId">Account identifier</param>
        /// <param name="from">Date to begin filtering transactions by, defaults to 180 days ago</param>
        /// <param name="to">Date to end filtering transactions by, defaults to today</param>
        /// <returns>
        ///     Account Transactions Response
        ///     <see cref="Investec.OpenBanking.RestClient.ResponseModels.Accounts.AccountTransactionsResponseModel" />
        /// </returns>
        public async Task<BaseResponseModel<AccountTransactionsResponseModel>> GetAccountTransactions(
            string accountId, DateTime? from = null, DateTime? to = null)
        {
            var from_ISO8601 = "";
            var to_ISO8601 = "";
            if (from.HasValue)
            {
                from_ISO8601 = from.Value.ToString("o");
            }

            if (to.HasValue)
            {
                to_ISO8601 = to.Value.ToString("o");
            }

            var transactions = await _accountsEndpoint.GetTransactions(accountId, from_ISO8601, to_ISO8601);
            if (_options.EnableTransactionClassification)
            {
                transactions.data.transactions = await _classificationService.ClassifyTransactions(transactions.data.transactions);
            }

            return transactions;
        }

        /// <summary>
        ///     GET /za/pb/v1/accounts{accountId}/balance
        ///     Obtain a specified account's balance.
        /// </summary>
        /// <param name="accountId">Account identifier</param>
        /// <returns>
        ///     Account Balance Response
        ///     <see cref="Investec.OpenBanking.RestClient.ResponseModels.Accounts.AccountBalanceResponseModel" />
        /// </returns>
        public async Task<BaseResponseModel<AccountBalanceResponseModel>> GetAccountBalance(string accountId) =>
            await _accountsEndpoint.GetBalance(accountId);
    }
}