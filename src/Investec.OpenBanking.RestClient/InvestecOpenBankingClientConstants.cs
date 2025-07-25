namespace Investec.OpenBanking.RestClient
{
    public static class InvestecOpenBankingClientConstants
    {
        public static string BaseUrl => "https://openapi.investec.com";
        public static string ApiVersion => "v1";
        public static string PrivateBankingApiUrl => $"{BaseUrl}/za/pb/{ApiVersion}";
        public static string ApiUrl => $"{BaseUrl}/za/{ApiVersion}";
    }
}