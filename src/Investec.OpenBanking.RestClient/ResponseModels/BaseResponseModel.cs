namespace Investec.OpenBanking.RestClient.ResponseModels
{
    public class BaseResponseModel<TData>
    {
        public BaseResponseModel(TData tData)
        {
            data = tData;
            links = new LinksResponse();
            meta = new MetaResponse();
        }

        public TData data { get; set; }
        public LinksResponse links { get; set; }
        public MetaResponse meta { get; set; }

        public class LinksResponse
        {
            public string self { get; set; }
        }

        public class MetaResponse
        {
            public int totalPages { get; set; }
        }
    }
}