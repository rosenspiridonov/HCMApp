using System.ComponentModel.DataAnnotations;

namespace CapitalManagement.Data.Entities
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
