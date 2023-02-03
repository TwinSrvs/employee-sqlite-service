using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assessment.ServiceHandler
{
    public class ProfileImageLink<T>
    {
        #region FIELDS

        private const string ImageAPI = " https://fakerapi.it/api/v1/images?_quantity=1";

        #endregion

        HttpClient _httpClient = new HttpClient();

        public async Task<T> GetProfileImage()
        {
            var content = await _httpClient.GetStringAsync(ImageAPI);
            var getImageModel = JsonConvert.DeserializeObject<T>(content);
            return getImageModel;
        }
    }
}