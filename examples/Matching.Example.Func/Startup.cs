using System;
using Investec.OpenBanking.RestClient.Extensions;
using Matching.Example.Func;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftGraph.RestClient.Extensions;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Matching.Example.Func
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddMicrosoftGraphClientService(options =>
            {
                options.ApplicationId = Environment.GetEnvironmentVariable("ApplicationId");
                options.ApplicationSecret = Environment.GetEnvironmentVariable("ApplicationSecret");
                options.RedirectUri = Environment.GetEnvironmentVariable("RedirectUri");
                options.TenantId = Environment.GetEnvironmentVariable("TenantId");
            });
            builder.Services.AddInvestecOpenBankingClientService(options =>
            {
                options.ClientId = Environment.GetEnvironmentVariable("ClientId");
                options.ClientSecret = Environment.GetEnvironmentVariable("ClientSecret");
            });
        }
    }
}