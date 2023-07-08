using CapitalManagement.Services.Api;

namespace CapitalManagement.Services.Users
{
    public interface IUserService
    {
        Task<ApiResponse> RegisterAsync(string username, string email, string password);

        Task<ApiResponse> LoginAsync(string username, string password); 
    }
}
