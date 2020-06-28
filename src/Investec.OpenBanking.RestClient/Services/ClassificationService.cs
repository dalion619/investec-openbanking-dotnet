using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Investec.OpenBanking.RestClient.Interfaces;

namespace Investec.OpenBanking.RestClient.Services
{
    public class ClassificationService:IClassificationService
    {
        private IBrowsingContext _browsingContext { get; set; }
        private IConfiguration _browsingConfig { get; set; }

        public ClassificationService()
        {
            _browsingConfig = Configuration.Default
                                           .WithDefaultLoader()
                                           .WithDefaultCookies();
            _browsingContext = BrowsingContext.New(_browsingConfig);
        }

        public async Task<string> LookupCategory(string wikiCode)
        {
            
            var document = await _browsingContext.OpenAsync( $"https://en.wikipedia.org/wiki/{wikiCode}");
            var vcard  = document.QuerySelector<IHtmlTableElement>(".infobox.vcard");
            if (vcard != null)
            {
                var industryRows = vcard.QuerySelectorAll<IHtmlTableCellElement>("th");
                var industryRow = industryRows.Where(w => !string.IsNullOrEmpty(w.Text())).FirstOrDefault(f =>
                    string.Equals(f.Text().Trim(), "industry",
                        StringComparison.InvariantCultureIgnoreCase))?.NextElementSibling;
                if (industryRow != null)
                {
                    var categories = industryRow.QuerySelectorAll<IHtmlAnchorElement>("a");
                    if (categories != null && categories.Any())
                    {
                        return categories.FirstOrDefault()?.Text().Trim();
                    }
                } 
            }
            
            return "";
        }
    }
}