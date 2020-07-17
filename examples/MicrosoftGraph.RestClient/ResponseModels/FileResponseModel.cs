namespace MicrosoftGraph.RestClient.ResponseModels
{
    public class FileResponseModel
    {
        public string mimeType { get; set; }
        public HashResponseModel hashes { get; set; }
    }

    public class HashResponseModel
    {
        public string quickXorHash { get; set; }
    }
}