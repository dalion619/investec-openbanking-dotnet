using Microsoft.Extensions.Options;

namespace MicrosoftGraph.RestClient.Options
{
    public class MicrosoftGraphClientOptions : IOptions<MicrosoftGraphClientOptions>
    {
        public string ApplicationId { get; set; }
        public string ApplicationSecret { get; set; }
        public string TenantId { get; set; }
        public string RedirectUri { get; set; }

        MicrosoftGraphClientOptions IOptions<MicrosoftGraphClientOptions>.Value => this;
    }
}