using System;
using Investec.OpenBanking.RestClient.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Polling.Example.Func;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Polling.Example.Func
{
    public class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient(); 
            builder.Services.AddInvestecOpenBankingClientService(options =>
            {
                options.ClientId = Environment.GetEnvironmentVariable("ClientId");
                options.ClientSecret = Environment.GetEnvironmentVariable("ClientSecret");
            });
        }
    }
}