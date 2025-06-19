using System;
using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.ResponseModels;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;
using Investec.OpenBanking.RestClient.ResponseModels.Cards;

namespace Investec.OpenBanking.RestClient.Interfaces
{
    public interface IInvestecOpenBankingClient
    {
        Task<AccessTokenResponseModel> GetAccessToken();
        Task<BaseResponseModel<CardsResponseModel>> GetCards();
        Task<BaseResponseModel<CardResponseModel>> GetCard(string cardKey);
        Task<BaseResponseModel<AccountsResponseModel>> GetAccounts();
        Task<BaseResponseModel<AccountTransactionsResponseModel>> GetAccountTransactions(
            string accountId, DateTime? fromDate = null, DateTime? toDate = null);
        Task<BaseResponseModel<AccountBalanceResponseModel>> GetAccountBalance(string accountId);
    }
}