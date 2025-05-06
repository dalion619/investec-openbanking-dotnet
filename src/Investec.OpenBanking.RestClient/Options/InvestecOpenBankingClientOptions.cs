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

        /// <summary>
        ///     If not supplied, will default to 'accounts'
        /// </summary>
        public string ApiKey { get; set; } 
        
        /// <summary>
        ///     Enable transaction classification feature, defaults to false
        /// </summary>
        public bool EnableTransactionClassification { get; set; }

        InvestecOpenBankingClientOptions IOptions<InvestecOpenBankingClientOptions>.Value => this;
    }
}