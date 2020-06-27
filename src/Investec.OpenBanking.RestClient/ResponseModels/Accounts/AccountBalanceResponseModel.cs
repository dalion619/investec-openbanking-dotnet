using System;
using System.Linq;

namespace Investec.OpenBanking.RestClient.ResponseModels.Accounts
{
    public class AccountBalanceResponseModel
    {
        public string accountId { get; set; }
        public decimal currentBalance { get; set; }
        public decimal availableBalance { get; set; }
        public string currency { get; set; }

        public CurrencyModel currencyModel => CurrencyHelper.GetCurrencies.FirstOrDefault(f =>
            string.Equals(f.ISO3, currency,
                StringComparison.InvariantCultureIgnoreCase));
    }
}