using System.Collections.Generic;

namespace MicrosoftGraph.RestClient.ResponseModels
{
    public class GroupDriveItemsResponseModel : BaseMicrosoftGraphResponseModel
    {
        public GroupDriveItemsResponseModel() => value = new List<GroupDriveItemResponseModel>();

        public List<GroupDriveItemResponseModel> value { get; set; }
    }
}