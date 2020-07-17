using Newtonsoft.Json;

namespace MicrosoftGraph.RestClient.ResponseModels
{
    public class BaseMicrosoftGraphResponseModel
    {
        [JsonProperty("@odata.context")] public string DataContext { get; set; }
    }
}