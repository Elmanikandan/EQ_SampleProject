using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Property.Web.Models;
using Property.Web.Services.Base;
using System.Net;

namespace Property.Web.Services
{
    public class RegistrationHttpservice : IApiService<RegistrationModel>
    {
        private readonly IOptions<ApiUrls> apiUrls;
        private readonly string registrationApiUrl;
        public RegistrationHttpservice(IOptions<ApiUrls> apiUrls)
        {
            this.apiUrls = apiUrls;
            registrationApiUrl = apiUrls.Value.RegistrationApiUrl;
        }
        public async Task<ApiResponseModel<RegistrationModel>> AddAsync(RegistrationModel registration)
        {
            ApiResponseModel<RegistrationModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PostAsJsonAsync<RegistrationModel>(registrationApiUrl, registration);
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    var reponseData = JsonConvert.DeserializeObject<RegistrationModel>(result);
                    response = new ApiResponseModel<RegistrationModel> { ResponseCode = HttpStatusCode.Created, Message = registration.Type + " created successfully", Record = reponseData };
                }                
            }
            return response;
        }

        public async Task<ApiResponseModel<RegistrationModel>> DeleteAsync(int? id)
        {
            var url = $"{registrationApiUrl}/{id}";
            ApiResponseModel<RegistrationModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.DeleteAsync(url);
                var result = await httpResponse.Content.ReadAsStringAsync();
                var reponseData = JsonConvert.DeserializeObject<RegistrationModel>(result);
                response = new ApiResponseModel<RegistrationModel> { ResponseCode = HttpStatusCode.OK, Message = reponseData.Type + " deleted successfully", Record = reponseData };
            }
            return response;
        }

        public async Task<ApiResponseModel<IEnumerable<RegistrationModel>>> GetAllAsync()
        {
            ApiResponseModel<IEnumerable<RegistrationModel>> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(registrationApiUrl);
                var result = await httpResponse.Content.ReadAsStringAsync();
               var data = JsonConvert.DeserializeObject<List<RegistrationModel>>(result);
                if (data != null && data.Count > 0)
                {
                    response = new ApiResponseModel<IEnumerable<RegistrationModel>> { ResponseCode = HttpStatusCode.Found, Message = "Records found", Record = data.ToList<RegistrationModel>() };
                }
                //response = await client.GetFromJsonAsync<ApiResponseModel<IEnumerable<RegistrationModel>>>(registrationApiUrl);
                
            }
            return response;
        }

        public async Task<ApiResponseModel<RegistrationModel>> GetAsync(int? id)
        {
            var url = $"{registrationApiUrl}/{id}";
            ApiResponseModel<RegistrationModel> response = null;
            using (var client = new HttpClient())
            {
                //response = await client.GetFromJsonAsync<ApiResponseModel<RegistrationModel>>(url);
                var httpResponse = await client.GetAsync(url);
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    var reponseData = JsonConvert.DeserializeObject<RegistrationModel>(result);
                    response = new ApiResponseModel<RegistrationModel> { ResponseCode = HttpStatusCode.Found, Message = "Data are found.", Record = reponseData };
                }
            }
            return response;
        }

        public async Task<ApiResponseModel<RegistrationModel>> UpdateAsync(RegistrationModel registration)
        {
            ApiResponseModel<RegistrationModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PutAsJsonAsync<RegistrationModel>(registrationApiUrl, registration);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = new ApiResponseModel<RegistrationModel> { ResponseCode = HttpStatusCode.OK, Message = registration.Type+ " updated successfully", Record = registration };
            }
            return response;
        }
    }
}
