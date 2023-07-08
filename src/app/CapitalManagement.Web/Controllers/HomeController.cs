using System.Diagnostics;

using CapitalManagement.Services.Api;
using CapitalManagement.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace CapitalManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}