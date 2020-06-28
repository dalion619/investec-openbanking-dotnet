using System.Threading.Tasks;

namespace Investec.OpenBanking.RestClient.Interfaces
{
    public interface IClassificationService
    {
        Task<string> LookupCategory(string wikiCode);
    }
}