using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.Options;
using Investec.OpenBanking.RestClient.ResponseModels.Cards;
using Investec.OpenBanking.RestClient.Services;
using Xunit;

namespace IntegrationTests;

public class CardTests
{
    public CardTests() =>
        _investecOpenBankingClient = new InvestecOpenBankingClient(
            new InvestecOpenBankingClientOptions
            {
                ClientId = Constants.ClientId,
                ClientSecret = Constants.ClientSecret,
                ApiKey = Constants.ApiKey
            }, new ClassificationService());

    private readonly InvestecOpenBankingClient _investecOpenBankingClient;
    
    [Fact]
    public async Task ValidGetCards()
    {
        var response = await _investecOpenBankingClient.GetCards();
        Assert.NotNull(response);
        Assert.NotNull(response.data);
        Assert.NotNull(response.data.cards);
        Assert.NotEmpty(response.data.cards);
        Assert.All(response.data.cards, card => Assert.NotNull(card));
        Assert.All(response.data.cards,
            card => Assert.NotEqual("Unknown", card.CardType));
    }
}