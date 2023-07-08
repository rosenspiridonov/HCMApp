using CapitalManagement.Services.Departments;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapitalManagement.Api.Controllers
{
    [Authorize]
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _departmentService.GetAllNames();

            return Ok(data);
        }
    }
}
