using System;
using Newtonsoft.Json;

namespace MicrosoftGraph.RestClient.ResponseModels
{
    public class GroupDriveItemResponseModel : BaseMicrosoftGraphResponseModel
    {
        [JsonProperty("@microsoft.graph.downloadUrl")]
        public string DownloadUrl { get; set; }

        public DateTime? createdDateTime { get; set; }
        public string eTag { get; set; }
        public string id { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
        public string name { get; set; }
        public string webUrl { get; set; }
        public string cTag { get; set; }
        public int size { get; set; }
        public ParentReferenceResponseModel parentReference { get; set; }
        public FileResponseModel file { get; set; }
        public FileSystemInfoResponseModel fileSystemInfo { get; set; }
    }
}