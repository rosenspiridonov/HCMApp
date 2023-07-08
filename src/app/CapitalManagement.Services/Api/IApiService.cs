namespace CapitalManagement.Services.Api
{
    public interface IApiService
    {
        Task<HttpResponseMessage> GetAsync(string endpoint);

        Task<HttpResponseMessage> PostAsync<T>(string endpoint, T content);

        Task<HttpResponseMessage> PutAsync<T>(string endpoint, T content);

        Task<HttpResponseMessage> DeleteAsync(string endpoint);
    }
}
