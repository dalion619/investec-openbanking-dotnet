using System;
using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.ResponseModels;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;

namespace Investec.OpenBanking.RestClient.Interfaces
{
    public interface IInvestecOpenBankingClient
    {
        Task<AccessTokenResponseModel> GetAccessToken();
        Task<BaseResponseModel<AccountsResponseModel>> GetAccounts();

        Task<BaseResponseModel<AccountTransactionsResponseModel>> GetAccountTransactions(
            string accountId, DateTime? fromDate = null, DateTime? toDate = null);

        Task<BaseResponseModel<AccountBalanceResponseModel>> GetAccountBalance(string accountId);
    }
}