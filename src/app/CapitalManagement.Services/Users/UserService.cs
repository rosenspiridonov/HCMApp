using System.Security.AccessControl;

using CapitalManagement.Services.Api;

namespace CapitalManagement.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IApiService _apiService;

        public UserService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ApiResponse> LoginAsync(string username, string password)
        {
            var requestModel = new LoginRequestModel
            {
                Username = username,
                Password = password
            };

            var response = await _apiService.PostAsync("/user/login", requestModel);

            return new ApiResponse(response);
        }

        public async Task<ApiResponse> RegisterAsync(string username, string email, string password)
        {
            var requestModel = new RegisterRequestModel
            {
                Username = username,
                Email = email,
                Password = password
            };

            var response = await _apiService.PostAsync("/user/register", requestModel);

            return new ApiResponse(response);
        }
    }
}
