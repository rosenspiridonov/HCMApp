using CapitalManagement.Services.Employees;

namespace CapitalManagement.Web.Models.Employees
{
    public class EmployeeViewModel : EmployeeModel
    {
        public IEnumerable<string>? DepartmentNames { get; set; }
    }
}
