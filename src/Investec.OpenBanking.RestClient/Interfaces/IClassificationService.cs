using System.Collections.Generic;
using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;
using Investec.OpenBanking.RestClient.Services;

namespace Investec.OpenBanking.RestClient.Interfaces
{
    public interface IClassificationService
    {
        Task<string> LookupCategory(string wikiCode);
        Task<List<ClassificationOverrideModel>> GetClassificationOverrides();

        Task<List<AccountTransactionsResponseModel.TransactionResponse>> ClassifyTransactions(
            List<AccountTransactionsResponseModel.TransactionResponse> transactions);
    }
}