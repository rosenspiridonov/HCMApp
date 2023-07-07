namespace CapitalManagement.Services.Users
{
    public interface IUserService
    {
        string GenerateJwtToken(string userId, string username, IList<string> roles, string secret);
    }
}
