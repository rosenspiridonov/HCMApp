using System.Reflection;

using CapitalManagement.Services.Departments;
using CapitalManagement.Services.Employees;
using CapitalManagement.Web.Infrastructure;
using CapitalManagement.Web.Models;
using CapitalManagement.Web.Models.Employees;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace CapitalManagement.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        [JwtAuthorize]
        public async Task<IActionResult> Index()
        {
            var response = await _employeeService.GetAllAsync();

            if (!response.Success)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel { Message = "Unable to retrieve employees." });
            }

            var model = JsonConvert.DeserializeObject<List<EmployeeModel>>(response.Data.ToString());
            return View(model);
        }

        [JwtAuthorize]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _employeeService.GetByIdAsync(id);

            if (!response.Success)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel { Message = $"Unable to retrieve details for employee with ID {id}." });
            }

            var model = JsonConvert.DeserializeObject<EmployeeModel>(response.Data.ToString());
            return View(model);
        }

        [HttpGet]
        [JwtAuthorize]
        public async Task<IActionResult> Create()
            => View(new EmployeeViewModel() 
            { 
                HireDate = DateTime.UtcNow,
                DepartmentNames = await _departmentService.GetAllNamesAsync() 
            });

        [HttpGet]
        [JwtAuthorize]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _employeeService.GetByIdAsync(id);

            if (!response.Success)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel { Message = $"Unable to retrieve details for employee with ID {id}." });
            }

            var model = JsonConvert.DeserializeObject<EmployeeViewModel>(response.Data.ToString());
            model.DepartmentNames = await _departmentService.GetAllNamesAsync();

            return View(model);
        }

        [HttpPost]
        [JwtAuthorize]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.DepartmentNames = model.DepartmentNames = await _departmentService.GetAllNamesAsync();
                return View(model);
            }

            var response = await _employeeService.CreateAsync(model);

            if (!response.Success)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel { Message = "Unable to create employee." });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [JwtAuthorize]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.DepartmentNames = model.DepartmentNames = await _departmentService.GetAllNamesAsync();
                return View(model);
            }

            var response = await _employeeService.UpdateAsync(model);

            if (!response.Success)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel { Message = $"Unable to update employee with ID {model.Id}." });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [JwtAuthorize]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _employeeService.DeleteAsync(id);

            if (!response.Success)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel { Message = $"Unable to delete employee with ID {id}." });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
