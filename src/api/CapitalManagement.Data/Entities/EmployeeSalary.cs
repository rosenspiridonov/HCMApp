using System.ComponentModel.DataAnnotations;

namespace CapitalManagement.Data.Entities
{
    public class EmployeeSalary : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
