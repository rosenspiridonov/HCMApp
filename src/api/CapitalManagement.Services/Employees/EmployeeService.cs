using CapitalManagement.Data;
using CapitalManagement.Data.Entities;
using CapitalManagement.Services.Departments;
using CapitalManagement.Services.Employees.Models;

using Microsoft.EntityFrameworkCore;

namespace CapitalManagement.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDepartmentService _departmentService;

        public EmployeeService(ApplicationDbContext context, IDepartmentService departmentService)
        {
            _context = context;
            _departmentService = departmentService;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllAsync()
            => await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Salaries)
                .Select(e => CreateEmployeeModel(e))
                .ToListAsync();

        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Salaries)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return null;
            }

            return CreateEmployeeModel(employee);
        }

        public async Task<EmployeeModel> GetByEmailAsync(string email)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Salaries)
                .FirstOrDefaultAsync(e => e.Email == email);

            if (employee == null)
            {
                return null;
            }

            return CreateEmployeeModel(employee);
        }

        public async Task<EmployeeModel> GetByPINAsync(string pin)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Salaries)
                .FirstOrDefaultAsync(e => e.PIN == pin);

            if (employee == null)
            {
                return null;
            }

            return CreateEmployeeModel(employee);
        }

        public async Task<int> CreateAsync(EmployeeModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(EmployeeModel));
            }

            var employee = new Employee()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                HireDate = DateTime.SpecifyKind(model.HireDate, DateTimeKind.Utc),
                PIN = model.PIN,
                DepartmentId = await _departmentService.GetIdAsync(model.DepartmentName)
            };

            var dateTimeNow = DateTime.UtcNow;

            employee.Salaries.Add(CreateEmployeeSalary(model.Salary));

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee.Id;
        }

        public async Task UpdateAsync(EmployeeModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(EmployeeModel));
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.PIN == model.PIN);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employee");
            }

            employee.FirstName = model.FirstName;
            employee.MiddleName = model.MiddleName;
            employee.LastName = model.LastName;
            employee.Email = model.Email;
            employee.HireDate = DateTime.SpecifyKind(model.HireDate, DateTimeKind.Utc);
            employee.PIN = model.PIN;

            if (employee.Department.Name != model.DepartmentName)
            {
                employee.DepartmentId = await _departmentService.GetIdAsync(model.DepartmentName);
            }

            var employeeSalary = await GetEmployeeSalaryAsync(employee.Id);

            if (employeeSalary != null && employeeSalary.Amount != model.Salary)
            {
                employeeSalary.IsActive = false;
                employee.Salaries.Add(CreateEmployeeSalary(model.Salary));
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        private static EmployeeModel CreateEmployeeModel(Employee employee)
            => new EmployeeModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Email = employee.Email,
                HireDate = employee.HireDate,
                PIN = employee.PIN,
                DepartmentName = employee.Department.Name,
                Salary = employee.Salaries.FirstOrDefault(s => s.IsActive).Amount
            };

        private async Task<EmployeeSalary> GetEmployeeSalaryAsync(int employeeId) 
            => await _context.EmployeeSalaries.FirstOrDefaultAsync(es => es.EmployeeId == employeeId && es.IsActive);

        private EmployeeSalary CreateEmployeeSalary(decimal salary)
        {
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be null");
            }

            return new EmployeeSalary
            {
                Amount = salary,
                StartDate = DateTime.UtcNow,
                IsActive = true
            };
        }
    }
}
