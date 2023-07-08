using System.ComponentModel.DataAnnotations;

namespace CapitalManagement.Data.Entities
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
            Salaries = new HashSet<EmployeeSalary>();
        }

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

        public bool IsActive { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<EmployeeSalary> Salaries { get; set; }
    }

}
