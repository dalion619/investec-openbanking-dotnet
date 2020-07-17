using System.Net.Http;
using System.Threading.Tasks;
using MicrosoftGraph.RestClient.ResponseModels;
using Refit;

namespace MicrosoftGraph.RestClient.Interfaces
{
    [Headers("Content-Type: application/json", "Accept: application/json")]
    public interface IGroups
    {
        [Get("/groups/{groupId}/drive/root:/{path}:/children")]
        Task<GroupDriveItemsResponseModel> GetFolderContents(string groupId, string path);

        [Put("/groups/{groupId}/drive/root:/{path}/{fileName}:/content")]
        Task<HttpResponseMessage> UploadText(string groupId, string path, string fileName, [Body] string content);
    }
}