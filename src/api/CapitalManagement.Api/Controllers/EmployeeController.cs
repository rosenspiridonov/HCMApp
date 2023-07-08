using CapitalManagement.Services.Employees.Models;
using CapitalManagement.Services.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CapitalManagement.Api.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var employee = await _employeeService.GetByEmailAsync(email);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet("pin/{pin}")]
        public async Task<IActionResult> GetByPIN(string pin)
        {
            var employee = await _employeeService.GetByPINAsync(pin);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid model");
            }

            var id = await _employeeService.CreateAsync(model);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid model");
            }

            await _employeeService.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
