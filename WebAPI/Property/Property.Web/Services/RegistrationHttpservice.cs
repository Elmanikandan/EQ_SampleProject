﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Property.Web.Models;
using Property.Web.Services.Base;

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
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<RegistrationModel>>(result);
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
                response = JsonConvert.DeserializeObject<ApiResponseModel<RegistrationModel>>(result);
            }
            return response;
        }

        public async Task<ApiResponseModel<IEnumerable<RegistrationModel>>> GetAllAsync()
        {
            ApiResponseModel<IEnumerable<RegistrationModel>> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<IEnumerable<RegistrationModel>>>(registrationApiUrl);
            }
            return response;
        }

        public async Task<ApiResponseModel<RegistrationModel>> GetAsync(int? id)
        {
            var url = $"{registrationApiUrl}/{id}";
            ApiResponseModel<RegistrationModel> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<RegistrationModel>>(url);
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
                response = JsonConvert.DeserializeObject<ApiResponseModel<RegistrationModel>>(result);
            }
            return response;
        }
    }
}
