using System.Threading.Tasks;
using MicrosoftGraph.RestClient.ResponseModels;

namespace MicrosoftGraph.RestClient.Interfaces
{
    public interface IMicrosoftGraphClient
    {
        Task<GroupDriveItemsResponseModel> GetDriveFolderContents(string groupId, string path);
        Task UploadJsonFileToDrive(string groupId, string path, string fileName, string content);
    }
}