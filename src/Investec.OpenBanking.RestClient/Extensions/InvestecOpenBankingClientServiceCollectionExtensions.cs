using System;
using Investec.OpenBanking.RestClient.Interfaces;
using Investec.OpenBanking.RestClient.Options;
using Investec.OpenBanking.RestClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Investec.OpenBanking.RestClient.Extensions
{
    /// <summary>
    ///     Adds the Investec Open Banking REST Client service to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="setupAction">
    ///     An <see cref="Action{T}" /> to configure the provided. <see cref="InvestecOpenBankingClientOptions" />
    /// </param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
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