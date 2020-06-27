using System;

namespace Investec.OpenBanking.RestClient.ResponseModels
{
    public class AccessTokenResponseModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public DateTime valid_from => DateTime.UtcNow;
        public DateTime valid_to => DateTime.UtcNow.AddSeconds(expires_in);
        public TimeSpan ttl => valid_to - valid_from;
    }
}