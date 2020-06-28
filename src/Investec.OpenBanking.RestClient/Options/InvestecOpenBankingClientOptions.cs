using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Investec.OpenBanking.RestClient.Options
{
    /// <summary>
    ///     Configuration options for <see cref="InvestecOpenBankingClient" />
    /// </summary>
    public class InvestecOpenBankingClientOptions : IOptions<InvestecOpenBankingClientOptions>
    {
        public InvestecOpenBankingClientOptions() => Scopes = new List<string>();

        /// <summary>
        ///     Client Id obtained from the Open API tab in the Programmable Banking overview.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        ///     Client Secret obtained from the Open API tab in the Programmable Banking overview
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        ///     Specify specific scopes if needed, will default to 'accounts'
        /// </summary>
        public List<string> Scopes { get; set; }

        InvestecOpenBankingClientOptions IOptions<InvestecOpenBankingClientOptions>.Value => this;
    }
}