using CapitalManagement.Common;

namespace CapitalManagement.Web.Extensions
{
    public static class SessionExtensions
    {
        public static bool IsUserLoggedIn(this ISession session)
        {
            return !string.IsNullOrEmpty(session.GetString(Constants.JwtTokenKey));
        }
    }
}
