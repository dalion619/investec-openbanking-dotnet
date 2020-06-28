using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.Options;
using Investec.OpenBanking.RestClient.Services;
using Xunit;

namespace IntegrationTests
{
    public class AccessTokenTests
    {
        public AccessTokenTests() =>
            _investecOpenBankingClient = new InvestecOpenBankingClient(
                new InvestecOpenBankingClientOptions
                {
                    ClientId = Constants.ClientId,
                    ClientSecret = Constants.ClientSecret
                },new ClassificationService());

        private readonly InvestecOpenBankingClient _investecOpenBankingClient;

        [Fact]
        public async Task ValidGetAccessToken()
        {
            var response = await _investecOpenBankingClient.GetAccessToken();
            Assert.NotNull(response);
            Assert.NotNull(response.access_token);
        }
    }
}