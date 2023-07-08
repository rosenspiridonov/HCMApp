using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapitalManagement.Services.Api;

namespace CapitalManagement.Services.Employees
{
    public interface IEmployeeService
    {
        Task<ApiResponse> GetAllAsync();

        Task<ApiResponse> GetByIdAsync(int id);

        Task<ApiResponse> CreateAsync(EmployeeModel model);

        Task<ApiResponse> UpdateAsync(EmployeeModel model);

        Task<ApiResponse> DeleteAsync(int id);
    }
}
