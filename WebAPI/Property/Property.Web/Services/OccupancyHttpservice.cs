using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Property.Web.Models;
using Property.Web.Services.Base;
using System.Net;

namespace Property.Web.Services
{
    public class OccupancyHttpservice : IApiService<Occupancy>
    {
        private readonly IOptions<ApiUrls> apiUrls;
        private readonly string occupancyApiUrl;
        public OccupancyHttpservice(IOptions<ApiUrls> apiUrls)
        {
            this.apiUrls = apiUrls;
            occupancyApiUrl = apiUrls.Value.PropertiesApiUrl;
        }

        public Task<ApiResponseModel<Occupancy>> AddAsync(Occupancy modelType)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseModel<Occupancy>> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponseModel<IEnumerable<Occupancy>>> GetAllAsync()
        {
            ApiResponseModel<IEnumerable<Occupancy>> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(occupancyApiUrl);
                var result = await httpResponse.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Occupancy>>(result);
                if (data != null && data.Count > 0)
                {
                    response = new ApiResponseModel<IEnumerable<Occupancy>> { ResponseCode = HttpStatusCode.Found, Message = "Records found", Record = data.ToList<Occupancy>() };
                }
            }
            return response;
        }

        public Task<ApiResponseModel<Occupancy>> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseModel<Occupancy>> UpdateAsync(Occupancy modelType)
        {
            throw new NotImplementedException();
        }
    }
}
