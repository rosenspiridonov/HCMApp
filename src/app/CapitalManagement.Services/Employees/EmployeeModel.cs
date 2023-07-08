using System.ComponentModel.DataAnnotations;

namespace CapitalManagement.Services.Employees
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public string PIN { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}
