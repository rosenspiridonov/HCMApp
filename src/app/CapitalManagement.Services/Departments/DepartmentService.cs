using System.Net.Http.Json;

using CapitalManagement.Services.Api;

using Newtonsoft.Json;

namespace CapitalManagement.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IApiService _apiService;

        public DepartmentService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<string>> GetAllNamesAsync()
        {
            var response = await _apiService.GetAsync("/department/all");
            Console.WriteLine(JsonConvert.SerializeObject(response));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();

                

                return content;
            }
            
            return new List<string>();
        }
    }
}
