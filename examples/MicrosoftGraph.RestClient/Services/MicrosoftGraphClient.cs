using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using MicrosoftGraph.RestClient.Interfaces;
using MicrosoftGraph.RestClient.Options;
using MicrosoftGraph.RestClient.ResponseModels;
using MicrosoftGraph.RestClient.Utilities;
using Refit;

namespace MicrosoftGraph.RestClient.Services
{
    public class MicrosoftGraphClient : IMicrosoftGraphClient
    {
        private readonly IGroups _groupsEndpoint;
        private readonly HttpClient _httpClient;
        private readonly MicrosoftGraphClientOptions _options;

        public MicrosoftGraphClient(IOptions<MicrosoftGraphClientOptions> optionsAccessor)
        {
            if (optionsAccessor == null)
            {
                throw new ArgumentNullException(nameof(optionsAccessor));
            }

            _options = optionsAccessor.Value;
            _httpClient = new HttpClient(new AuthHandler(CreateAuthorizationProvider(), new HttpClientHandler()))
                          {
                              Timeout = TimeSpan
                                  .FromSeconds(30),
                              BaseAddress = new Uri(MicrosoftGraphClientConstants.ApiUrl)
                          };
            _groupsEndpoint = RestService.For<IGroups>(_httpClient);
        }

        public async Task<GroupDriveItemsResponseModel> GetDriveFolderContents(string groupId, string path)
        {
            try
            {
                return await _groupsEndpoint.GetFolderContents(groupId, path);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return null;
        }

        public async Task UploadJsonFileToDrive(string groupId, string path, string fileName, string content)
        {
            try
            {
                await _groupsEndpoint.UploadText(groupId, path, $"{fileName}.json", content);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private IAuthenticationProvider CreateAuthorizationProvider()
        {
            var clientId = _options.ApplicationId;
            var clientSecret = _options.ApplicationSecret;
            var redirectUri = _options.RedirectUri;
            var authority = $"https://login.microsoftonline.com/{_options.TenantId}/v2.0";

            //this specific scope means that application will default to what is defined in the application registration rather than using dynamic scopes
            var scopes = new List<string>();
            scopes.Add("https://graph.microsoft.com/.default");

            var cca = ConfidentialClientApplicationBuilder.Create(clientId)
                                                          .WithAuthority(authority)
                                                          .WithRedirectUri(redirectUri)
                                                          .WithClientSecret(clientSecret)
                                                          .Build();
            return new MsalAuthenticationProvider(cca, scopes.ToArray());
        }
    }
}