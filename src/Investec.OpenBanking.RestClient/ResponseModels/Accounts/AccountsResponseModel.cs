using System.Collections.Generic;

namespace Investec.OpenBanking.RestClient.ResponseModels.Accounts
{
    public class AccountsResponseModel
    {
        public enum AccountProducts
        {
            Unknown = -1,
            PrivateBankAccount = 0,
            PrimeSaver = 1,
            CashManagementAccount = 2
        }

        public AccountsResponseModel() => accounts = new List<AccountResponse>();

        public List<AccountResponse> accounts { get; set; }

        public class AccountResponse
        {
            public string accountId { get; set; }
            public string accountNumber { get; set; }
            public string accountName { get; set; }
            public string referenceName { get; set; }
            public string productName { get; set; }

            public AccountProducts product
            {
                get
                {
                    switch (productName.ToLowerInvariant())
                    {
                        case "private bank account":
                            return AccountProducts.PrivateBankAccount;
                        case "primesaver":
                            return AccountProducts.PrimeSaver;
                        case "cash management account":
                            return AccountProducts.CashManagementAccount;
                    }

                    return AccountProducts.Unknown;
                }
            }
        }
    }
}