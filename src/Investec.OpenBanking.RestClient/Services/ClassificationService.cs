using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Investec.OpenBanking.RestClient.Interfaces;
using Newtonsoft.Json;

namespace Investec.OpenBanking.RestClient.Services
{
    public class ClassificationService : IClassificationService
    {
        public ClassificationService()
        {
            _browsingConfig = Configuration.Default
                                           .WithDefaultLoader()
                                           .WithDefaultCookies();
            _browsingContext = BrowsingContext.New(_browsingConfig);
        }

        private IBrowsingContext _browsingContext { get; }
        private IConfiguration _browsingConfig { get; }

        private string ExecutingAppDirectoryPath
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var codeBaseUri = new UriBuilder(codeBase);
                var uriPath = Uri.UnescapeDataString(codeBaseUri.Path);
                return Path.GetDirectoryName(uriPath);
            }
        }

        public async Task<string> LookupCategory(string wikiCode)
        {
            try
            {
                var document = await _browsingContext.OpenAsync($"https://en.wikipedia.org/wiki/{wikiCode}");
                var vcard = document.QuerySelector<IHtmlTableElement>(".infobox.vcard");
                if (vcard != null)
                {
                    var industryRows = vcard.QuerySelectorAll<IHtmlTableCellElement>("th");
                    var industryRow = industryRows.Where(w => !string.IsNullOrEmpty(w.Text())).FirstOrDefault(f =>
                                                      string.Equals(f.Text().Trim(), "industry",
                                                          StringComparison.InvariantCultureIgnoreCase))
                                                  ?.NextElementSibling;
                    if (industryRow != null)
                    {
                        var categories = industryRow.QuerySelectorAll<IHtmlAnchorElement>("a");
                        if (categories != null && categories.Any())
                        {
                            return categories.FirstOrDefault()?.Text().Trim();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return "";
        }

        public async Task<List<ClassificationOverrideModel>> GetClassificationOverrides()
        {
            try
            {
                var fileInfo = new FileInfo($@"{ExecutingAppDirectoryPath}\classification-override.json");
                if (fileInfo.Exists)
                {
                    var json = await File.ReadAllTextAsync(fileInfo.FullName);
                    return JsonConvert.DeserializeObject<List<ClassificationOverrideModel>>(json);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return new List<ClassificationOverrideModel>();
        }
    }

    public class ClassificationOverrideModel
    {
        public enum OverrideType
        {
            Equals,
            Contains
        }

        public string Lookup { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
        public string Replace { get; set; }
        public OverrideType Type { get; set; }
    }
}