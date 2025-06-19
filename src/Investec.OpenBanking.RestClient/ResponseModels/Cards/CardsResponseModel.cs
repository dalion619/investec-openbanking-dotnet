using System.Collections.Generic;

namespace Investec.OpenBanking.RestClient.ResponseModels.Cards
{
    public class CardsResponseModel
    {
        public CardsResponseModel() => cards = new List<CardResponse>();
        public List<CardResponse> cards { get; set; }
        public class CardResponse
        {
            public string CardKey { get; set; }
            public string CardNumber { get; set; }
            public bool IsProgrammable { get; set; }
            public string Status { get; set; }
            public string CardType
            {
                get
                {
                    switch (CardTypeCode)
                    {
                        // Business (VB)
                        case "VBC":
                            return "Physical Business Card";
                        case "VVB":
                            return "Virtual Business Card";
                        // Platinum (VG)
                        case "VGC":
                            return "Physical Platinum Card";
                        case "VVG":
                            return "Virtual Platinum Card";
                        // Youth (VF)
                        case "VDP":
                            return "Physical Youth Card";
                        case "VVD":
                            return "Virtual Youth Card";
                        // Corporate (VC)
                        case "VCC":
                            return "Physical Corporate Card";
                        case "VVC":
                            return "Virtual Corporate Card";
                    }
                    return "Unknown";
                }
            }
            public string CardTypeCode { get; set; }
            public string AccountNumber { get; set; }
            public string AccountId { get; set; }
            public string EmbossedName { get; set; }
            public bool IsVirtualCard { get; set; }
        }
    }
}