using System.Linq;
using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.Options;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;
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
    
    [Fact]
    public async Task ValidGetCard()
    {
        var cards = await _investecOpenBankingClient.GetCards();
        var card = cards.data.cards.FirstOrDefault();
        Assert.NotNull(card);

        var response = await _investecOpenBankingClient.GetCard(card.CardKey);
        Assert.NotNull(response);
        Assert.NotNull(response.data);
        Assert.NotNull(response.data.result);
    }
}