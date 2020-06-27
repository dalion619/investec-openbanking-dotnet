using System.Collections.Generic;
using System.Linq;

namespace Investec.OpenBanking.RestClient.RequestModels
{
    public class AccessTokenRequestModel
    {
        public AccessTokenRequestModel(List<string> scopes = null)
        {
            if (scopes == null || !scopes.Any())
            {
                scopes = new List<string> {"accounts"};
            }

            scope = string.Join(',', scopes);
        }

        public string grant_type => "client_credentials";
        public string scope { get; set; }
    }
}