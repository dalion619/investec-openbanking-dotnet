using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Investec.OpenBanking.RestClient.Options
{
    public class InvestecOpenBankingClientOptions : IOptions<InvestecOpenBankingClientOptions>
    {
        public InvestecOpenBankingClientOptions() => Scopes = new List<string>();

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public List<string> Scopes { get; set; }

        InvestecOpenBankingClientOptions IOptions<InvestecOpenBankingClientOptions>.Value => this;
    }
}