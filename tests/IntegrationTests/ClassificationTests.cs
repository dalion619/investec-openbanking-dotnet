using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.Interfaces;
using Investec.OpenBanking.RestClient.Services;
using Xunit;

namespace IntegrationTests
{
    public class ClassificationTests
    {
        private readonly IClassificationService _classificationService;

        public ClassificationTests()
        {
            _classificationService = new ClassificationService();
        }
        
        [Fact]
        public async Task ValidSingleCategory()
        {
            var category = await _classificationService.LookupCategory("Uber_Eats");
            Assert.NotNull(category);
        }
         
        [Fact]
        public async Task ValidFirstCategory()
        {
            var category = await _classificationService.LookupCategory("Microsoft");
            Assert.NotNull(category);
        }
    }
}