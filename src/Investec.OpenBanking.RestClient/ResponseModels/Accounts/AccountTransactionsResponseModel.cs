using System;
using System.Collections.Generic;

namespace Investec.OpenBanking.RestClient.ResponseModels.Accounts
{
    public class AccountTransactionsResponseModel
    {
        public enum TransactionStatuses
        {
            Unknown = -1,
            Posted = 0
        }

        public enum TransactionTypes
        {
            Unknown = -1,
            Credit = 0,
            Debit = 1
        }

        public AccountTransactionsResponseModel() => transactions = new List<TransactionResponse>();

        public List<TransactionResponse> transactions { get; set; }

        public class TransactionResponse
        {
            public string accountId { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public string description { get; set; }
            public string cardNumber { get; set; }
            public string postingDate { get; set; }
            public string valueDate { get; set; }
            public string actionDate { get; set; }
            public string transactionDate { get; set; }
            public TransactionClassification classification { get; set; }
            public decimal amount { get; set; }
            public DateTime postingDateTime => DateTime.Parse(postingDate);
            public DateTime valueDateTime => DateTime.Parse(valueDate);
            public DateTime actionDateTime => DateTime.Parse(actionDate);
            public DateTime transactionDateTime => DateTime.Parse(transactionDate);

            public TransactionStatuses transactionStatus
            {
                get
                {
                    switch (status.ToLowerInvariant())
                    {
                        case "posted":
                            return TransactionStatuses.Posted;
                    }

                    return TransactionStatuses.Unknown;
                }
            }

            public TransactionTypes transactionType
            {
                get
                {
                    switch (type.ToLowerInvariant())
                    {
                        case "credit":
                            return TransactionTypes.Credit;
                        case "debit":
                            return TransactionTypes.Debit;
                    }

                    return TransactionTypes.Unknown;
                }
            }
        }

        public class TransactionClassification
        {
            public string merchant { get; set; }
            public string category { get; set; }
            public string wiki_code { get; set; }
            public CountryModel countryModel { get; set; }
        }
    }
}