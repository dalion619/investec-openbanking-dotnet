using System;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftGraph.RestClient.Interfaces;
using MicrosoftGraph.RestClient.Options;
using MicrosoftGraph.RestClient.Services;

namespace MicrosoftGraph.RestClient.Extensions
{
    public static class MicrosoftGraphClientServiceCollectionExtensions
    {
        public static IServiceCollection AddMicrosoftGraphClientService(this IServiceCollection services,
                                                                        Action<MicrosoftGraphClientOptions>
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
            services.AddHttpClient();
            services.Add(ServiceDescriptor.Singleton<IMicrosoftGraphClient, MicrosoftGraphClient>());

            return services;
        }
    }
}