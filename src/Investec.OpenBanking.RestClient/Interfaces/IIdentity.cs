using System.Collections.Generic;
using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.ResponseModels;
using Refit;

namespace Investec.OpenBanking.RestClient.Interfaces
{
    public interface IIdentity
    {
        [Post("/identity/v2/oauth2/token")]
        Task<AccessTokenResponseModel> GetAccessToken([Header("Authorization")] string basicAuth,
                                                      [Body(BodySerializationMethod.UrlEncoded)]
                                                      Dictionary<string, object> data);
    }
}