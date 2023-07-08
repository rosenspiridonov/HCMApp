namespace CapitalManagement.Services.Employees.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime HireDate { get; set; }

        public string PIN { get; set; }

        public string DepartmentName { get; set; }

        public decimal Salary { get; set; }
    }
}
