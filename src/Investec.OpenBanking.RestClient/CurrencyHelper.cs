using System.Collections.Generic;
using Newtonsoft.Json;

namespace Investec.OpenBanking.RestClient
{
  /// <summary>
  ///     Helper class with basic information on various currencies
  /// </summary>
  public static class CurrencyHelper
    {
        private static string CurrenciesJson => @"[
  {
    ""ISO3"": ""AUD"",
    ""Name"": ""Australian Dollar"",
    ""Symbol"": ""AU$"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""BGN"",
    ""Name"": ""Bulgarian Lev"",
    ""Symbol"": ""лв"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""BRL"",
    ""Name"": ""Brazilian Real"",
    ""Symbol"": ""R$"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""CAD"",
    ""Name"": ""Canadian Dollar"",
    ""Symbol"": ""CA$"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""CHF"",
    ""Name"": ""Swiss Franc"",
    ""Symbol"": ""CHF"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""CNY"",
    ""Name"": ""Chinese Yuan"",
    ""Symbol"": ""¥"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""CZK"",
    ""Name"": ""Czech Republic Koruna"",
    ""Symbol"": ""Kč"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""DKK"",
    ""Name"": ""Danish Krone"",
    ""Symbol"": ""kr."",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""EUR"",
    ""Name"": ""Euro"",
    ""Symbol"": ""€"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""GBP"",
    ""Name"": ""British Pound Sterling"",
    ""Symbol"": ""£"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""HKD"",
    ""Name"": ""Hong Kong Dollar"",
    ""Symbol"": ""HK$"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""HRK"",
    ""Name"": ""Croatian Kuna"",
    ""Symbol"": ""kn"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""HUF"",
    ""Name"": ""Hungarian Forint"",
    ""Symbol"": ""Ft"",
    ""DecimalPoints"": 0
  },
  {
    ""ISO3"": ""IDR"",
    ""Name"": ""Indonesian Rupiah"",
    ""Symbol"": ""Rp"",
    ""DecimalPoints"": 0
  },
  {
    ""ISO3"": ""ILS"",
    ""Name"": ""Israeli NewSheqel"",
    ""Symbol"": ""₪"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""INR"",
    ""Name"": ""Indian Rupee"",
    ""Symbol"": ""Rs"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""ISK"",
    ""Name"": ""Icelandic Króna"",
    ""Symbol"": ""Ikr"",
    ""DecimalPoints"": 0
  },
  {
    ""ISO3"": ""JPY"",
    ""Name"": ""Japanese Yen"",
    ""Symbol"": ""¥"",
    ""DecimalPoints"": 0
  },
  {
    ""ISO3"": ""KRW"",
    ""Name"": ""South Korean Won"",
    ""Symbol"": ""₩"",
    ""DecimalPoints"": 0
  },
  {
    ""ISO3"": ""MXN"",
    ""Name"": ""Mexican Peso"",
    ""Symbol"": ""MX$"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""MYR"",
    ""Name"": ""Malaysian Ringgit"",
    ""Symbol"": ""RM"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""NOK"",
    ""Name"": ""Norwegian Krone"",
    ""Symbol"": ""kr"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""NZD"",
    ""Name"": ""New Zealand Dollar"",
    ""Symbol"": ""NZ$"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""PHP"",
    ""Name"": ""Philippine Peso"",
    ""Symbol"": ""₱"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""PLN"",
    ""Name"": ""Polish Zloty"",
    ""Symbol"": ""zl"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""RON"",
    ""Name"": ""Romanian Leu"",
    ""Symbol"": ""lei"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""RUB"",
    ""Name"": ""Russian Ruble"",
    ""Symbol"": ""₽"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""SEK"",
    ""Name"": ""Swedish Krona"",
    ""Symbol"": ""kr"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""SGD"",
    ""Name"": ""Singapore Dollar"",
    ""Symbol"": ""S$"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""THB"",
    ""Name"": ""Thai Baht"",
    ""Symbol"": ""฿"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""TRY"",
    ""Name"": ""Turkish Lira"",
    ""Symbol"": ""₺"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""USD"",
    ""Name"": ""US Dollar"",
    ""Symbol"": ""$"",
    ""DecimalPoints"": 2
  },
  {
    ""ISO3"": ""ZAR"",
    ""Name"": ""South African Rand"",
    ""Symbol"": ""R"",
    ""DecimalPoints"": 2
  }
]";

        /// <summary>
        ///     Returns a collection currencies with their basic information
        /// </summary>
        public static IReadOnlyList<CurrencyModel> GetCurrencies =>
            JsonConvert.DeserializeObject<List<CurrencyModel>>(CurrenciesJson);
    }

  /// <summary>
  ///     Currency model
  /// </summary>
  public class CurrencyModel
    {
      /// <summary>
      ///     Currency ISO 4217 Alpha-3 code
      /// </summary>
      public string ISO3 { get; set; }

      /// <summary>
      ///     Currency name
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      ///     Currency symbol
      /// </summary>
      public string Symbol { get; set; }

      /// <summary>
      ///     Currency decimal points/places
      /// </summary>
      public int DecimalPoints { get; set; }
    }
}