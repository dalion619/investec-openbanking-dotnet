using System;
using Investec.OpenBanking.RestClient.Interfaces;
using Investec.OpenBanking.RestClient.Options;
using Investec.OpenBanking.RestClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Investec.OpenBanking.RestClient.Extensions
{
    public static class InvestecOpenBankingClientServiceCollectionExtensions
    {
        public static IServiceCollection AddInvestecOpenBankingClientService(this IServiceCollection services,
                                                                             Action<InvestecOpenBankingClientOptions>
                                                                                 setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.AddOptions();
            services.Configure(setupAction);
            services.Add(ServiceDescriptor.Singleton<IInvestecOpenBankingClient, InvestecOpenBankingClient>());

            return services;
        }
    }
}