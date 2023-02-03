using System.Threading.Tasks;
using Assessment.ServiceHandler;
using Newtonsoft.Json;

namespace Assessment.Models
{
    public class ImageDetails
    {
        #region PROPERTIES

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        #endregion

       public async Task PopulateFromResponse()
       {
            var image = await new ProfileImageLink<APIResponse>().GetProfileImage();
            Url = image.Data[0].Url;
            Title = image.Data[0].Title;
       }
    }
}