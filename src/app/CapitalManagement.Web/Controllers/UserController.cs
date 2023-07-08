using System.Security.Claims;
using CapitalManagement.Services.Users;
using CapitalManagement.Web.Models.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using CapitalManagement.Common;
using System.IdentityModel.Tokens.Jwt;

namespace CapitalManagement.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register() => View();

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.RegisterAsync(model.Username, model.Email, model.Password);

            if (!result.Success)
            {
                return BadRequest("Invalid data");
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.LoginAsync(model.Username, model.Password);
            var token = result.Data;

            Console.WriteLine("Token: " + token);

            if (string.IsNullOrWhiteSpace(token))
            {
                return BadRequest("Invalid login credentials");
            }

            HttpContext.Session.SetString(Constants.JwtTokenKey, token);

            // NOT WORKING
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var identity = new ClaimsIdentity(jwtToken.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Redirect("/");
        }
    }
}
