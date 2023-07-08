using System.Text;

using CapitalManagement.Common;

using Newtonsoft.Json;

namespace CapitalManagement.Services.Api
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _client;

        public ApiService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(Constants.ApiClientName);
            _client.BaseAddress = new Uri("http://api:80");
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await _client.GetAsync(endpoint);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T content)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            return await _client.PostAsync(endpoint, jsonContent);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T content)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            return await _client.PutAsync(endpoint, jsonContent);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            return await _client.DeleteAsync(endpoint);
        }
    }
}
