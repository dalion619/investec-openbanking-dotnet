namespace Investec.OpenBanking.RestClient.ResponseModels.Cards
{
    public class CardResponseModel
    {
        public CardResponseModel() => result = new CardResponse();
        public CardResponse result { get; set; }
        public class CardResponse
        {
            public string CardKeyHash { get; set; }
            public string MaskedCardNumber { get; set; }
            public string EmbossName { get; set; }
            public string EmbossName2 { get; set; }
            public string Status { get; set; }
            public string AccountNumber { get; set; }
            public bool IsVirtualCard { get; set; }
            public object ExtendedDetails { get; set; }
        }
    }
}