using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assessment.Models
{
    public class APIResponse
    {
        #region PROPERTIES

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("data")]
        public List<ImageDetails> Data { get; set; }

        #endregion
    }
}