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
    }
}