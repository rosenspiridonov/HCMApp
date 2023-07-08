using CapitalManagement.Services.Api;

namespace CapitalManagement.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApiService _apiService;

        public EmployeeService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            var response = await _apiService.GetAsync("/employee");
            return new ApiResponse(response);
        }

        public async Task<ApiResponse> GetByIdAsync(int id)
        {
            var response = await _apiService.GetAsync($"/employee/{id}");
            return new ApiResponse(response);
        }

        public async Task<ApiResponse> CreateAsync(EmployeeModel model)
        {
            var response = await _apiService.PostAsync("/employee", model);
            return new ApiResponse(response);
        }

        public async Task<ApiResponse> UpdateAsync(EmployeeModel model)
        {
            var response = await _apiService.PutAsync("/employee", model);
            return new ApiResponse(response);
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            var response = await _apiService.DeleteAsync($"/employee/{id}");
            return new ApiResponse(response);
        }
    }
}
