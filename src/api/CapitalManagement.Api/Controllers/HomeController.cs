using CapitalManagement.Data;

using Microsoft.AspNetCore.Mvc;

namespace CapitalManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Get()
        {
            var data = _context.People.ToList();

            return Ok(data);
        }
    }
}