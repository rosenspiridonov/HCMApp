using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CapitalManagement.Common;

namespace CapitalManagement.Web.Infrastructure
{
    public class JwtAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var httpContextAccessor = context.HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>();
            var session = httpContextAccessor.HttpContext.Session;

            var token = session.GetString(Constants.JwtTokenKey);
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectToActionResult("Login", "User", null);
            }
        }
    }
}
