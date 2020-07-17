using System;

namespace Matching.Example.Func
{
    public class AfterTransactionModel
    {
        public string accountNumber { get; set; }
        public DateTime? dateTime { get; set; }
        public int centsAmount { get; set; }
        public string currencyCode { get; set; }
        public string type { get; set; }
        public string reference { get; set; }
        public Card card { get; set; }
        public Merchant merchant { get; set; }

        public class Card
        {
            public string id { get; set; }
            public string display { get; set; }
        }

        public class Merchant
        {
            public Category category { get; set; }
            public string name { get; set; }
            public string city { get; set; }
            public Country country { get; set; }

            public class Country
            {
                public string code { get; set; }
                public string alpha3 { get; set; }
                public string name { get; set; }
            }

            public class Category
            {
                public string code { get; set; }
                public string key { get; set; }
                public string name { get; set; }
            }
        }
    }
}