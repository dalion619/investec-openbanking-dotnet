using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.ResponseModels;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;
using Refit;

namespace Investec.OpenBanking.RestClient.Interfaces
{
    [Headers("Authorization:Bearer", "User-Agent: Investec.OpenAPI.RestClient", "Content-Type: application/json",
        "Accept: application/json")]
    public interface IAccounts
    {
        [Get("/accounts")]
        Task<BaseResponseModel<AccountsResponseModel>> GetAccounts();

        [Get("/accounts/{accountId}/transactions")]
        Task<BaseResponseModel<AccountTransactionsResponseModel>> GetTransactions(string accountId);

        [Get("/accounts/{accountId}/balance")]
        Task<BaseResponseModel<AccountBalanceResponseModel>> GetBalance(string accountId);
    }
}