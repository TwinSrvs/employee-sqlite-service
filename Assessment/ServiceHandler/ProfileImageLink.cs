using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assessment.ServiceHandler
{
    public class ProfileImageLink<APIResponse>
    {
        #region FIELDS

        private const string ImageAPI = " https://fakerapi.it/api/v1/images?_quantity=1";

        #endregion

        HttpClient _httpClient = new HttpClient();

        public async Task<APIResponse> GetProfileImage()
        {
            var content = await _httpClient.GetStringAsync(ImageAPI);
            var getImageModel = JsonConvert.DeserializeObject<APIResponse>(content);
            return getImageModel;
        }
    }
}