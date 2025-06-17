using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.ResponseModels;
using Investec.OpenBanking.RestClient.ResponseModels.Cards;
using Refit;
namespace Investec.OpenBanking.RestClient.Interfaces
{
    [Headers("Authorization:Bearer", "User-Agent: Investec.OpenAPI.RestClient", "Content-Type: application/json",
        "Accept: application/json")]
    public interface ICards
    {
        [Get("/cards")]
        Task<BaseResponseModel<CardsResponseModel>> GetCards();
    }
}