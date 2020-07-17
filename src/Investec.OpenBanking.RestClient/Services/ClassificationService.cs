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
using Investec.OpenBanking.RestClient.Extensions;
using Investec.OpenBanking.RestClient.Interfaces;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;
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

        public async Task<List<AccountTransactionsResponseModel.TransactionResponse>> ClassifyTransactions(
            List<AccountTransactionsResponseModel.TransactionResponse> transactions)
        {
            var classificationOverrides = await GetClassificationOverrides();
            foreach (var transaction in transactions)
            {
                try
                {
                    var classification = new AccountTransactionsResponseModel.TransactionClassification();
                    if (string.IsNullOrEmpty(transaction.cardNumber))
                    {
                        classification.merchant = "Investec";
                        classification.countryModel =
                            CountryHelper.GetCountries.FirstOrDefault(f =>
                                string.Equals(f.ISO2, "ZA", StringComparison.InvariantCultureIgnoreCase));
                        if (transaction.transactionType == AccountTransactionsResponseModel.TransactionTypes.Credit)
                        {
                            classification.category = "Bank Transfer";
                        }
                        else
                        {
                            classification.category = "Bank Fee";
                        }

                        transaction.classification = classification;
                    }
                    else
                    {
                        var descriptionOverrides = classificationOverrides.Where(w =>
                            string.Equals(w.Lookup, "description", StringComparison.InvariantCultureIgnoreCase));
                        foreach (var item in descriptionOverrides)
                        {
                            classification = await ApplyOverride(item, transaction.description, classification);
                        }

                        var description = transaction.description;
                        if (description.Contains("*"))
                        {
                            var index = description.IndexOf("*");
                            description = description.Substring(index + 1).Trim();
                        }

                        var countryCode = description.Substring(description.Length - 2);
                        classification.countryModel =
                            CountryHelper.GetCountries.FirstOrDefault(f =>
                                string.Equals(f.ISO2, countryCode,
                                    StringComparison.InvariantCultureIgnoreCase));

                        var descriptionsParts = description
                                                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                                .ToList();
                        if (string.IsNullOrEmpty(classification.merchant))
                        {
                            switch (descriptionsParts.Count)
                            {
                                case 6:
                                    classification.merchant =
                                        $"{descriptionsParts[0]} {descriptionsParts[1]} {descriptionsParts[2]}".Trim();
                                    break;
                                case 5:
                                    classification.merchant = $"{descriptionsParts[0]} {descriptionsParts[1]}".Trim();
                                    break;
                                default:
                                    classification.merchant = descriptionsParts[0].Trim();
                                    break;
                            }
                        }

                        var merchantOverrides = classificationOverrides.Where(w =>
                            string.Equals(w.Lookup, "merchant", StringComparison.InvariantCultureIgnoreCase));
                        foreach (var item in merchantOverrides)
                        {
                            classification = await ApplyOverride(item, classification.merchant, classification);
                        }

                        classification.wiki_code = classification.merchant.SentenceCase().Replace(" ", "_");
                        var existingClassification = transactions
                                                     .FirstOrDefault(f =>
                                                         f.classification != null && string.Equals(f.classification.wiki_code,
                                                             classification.wiki_code,
                                                             StringComparison.InvariantCultureIgnoreCase))?.classification;
                        if (existingClassification != null)
                        {
                            transaction.classification = existingClassification;
                            continue;
                        }

                        if (string.IsNullOrEmpty(classification.category))
                        {
                            classification.category = await LookupCategory(classification.wiki_code);
                        }

                        var categoryOverrides = classificationOverrides.Where(w =>
                            string.Equals(w.Lookup, "category", StringComparison.InvariantCultureIgnoreCase));
                        foreach (var item in categoryOverrides)
                        {
                            classification = await ApplyOverride(item, classification.category, classification);
                        }

                        transaction.classification = classification;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }

            return transactions;
        }

        private async Task<AccountTransactionsResponseModel.TransactionClassification> ApplyOverride(
            ClassificationOverrideModel overrideModel, string input,
            AccountTransactionsResponseModel.TransactionClassification classification)
        {
            try
            {
                var newValue = "";
                switch (overrideModel.Type)
                {
                    case ClassificationOverrideModel.OverrideType.Equals:
                        if (string.Equals(input, overrideModel.Value, StringComparison.InvariantCultureIgnoreCase))
                        {
                            newValue = overrideModel.Replace;
                        }

                        break;
                    case ClassificationOverrideModel.OverrideType.Contains:
                        if (input.ToLower().Contains(overrideModel.Value.ToLower()))
                        {
                            newValue = overrideModel.Replace;
                        }

                        break;
                }

                if (!string.IsNullOrEmpty(newValue))
                {
                    switch (overrideModel.Property.ToLower())
                    {
                        case "merchant":
                            classification.merchant = newValue;
                            break;
                        case "category":
                            classification.category = newValue;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return classification;
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