using System.Text;

using CapitalManagement.Common;
using CapitalManagement.Services.Api;
using CapitalManagement.Services.Departments;
using CapitalManagement.Services.Employees;
using CapitalManagement.Services.Users;
using CapitalManagement.Web.Infrastructure;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;

namespace CapitalManagement.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, string jwtKey)
        {
            var key = Encoding.ASCII.GetBytes(jwtKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
            })
            .AddCookie();

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<AuthorizationHeaderHandler>();
            services.AddHttpClient(Constants.ApiClientName)
                .AddHttpMessageHandler<AuthorizationHeaderHandler>();

            services
                .AddTransient<IApiService, ApiService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IDepartmentService, DepartmentService>()
                .AddTransient<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
