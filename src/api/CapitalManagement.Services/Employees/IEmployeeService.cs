using CapitalManagement.Services.Employees.Models;

namespace CapitalManagement.Services.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetAllAsync();

        Task<EmployeeModel> GetByIdAsync(int id);

        Task<EmployeeModel> GetByPINAsync(string pin);

        Task<EmployeeModel> GetByEmailAsync(string email);

        Task<int> CreateAsync(EmployeeModel model);

        Task UpdateAsync(EmployeeModel model);

        Task DeleteAsync(int id);
    }
}
