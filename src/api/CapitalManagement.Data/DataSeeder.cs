using CapitalManagement.Data.Entities;

namespace CapitalManagement.Data
{
    public static class DataSeeder
    {
        public static void CreateDepartments(ApplicationDbContext context)
        {
            if (context.Departments.Any())
            {
                return;
            }

            var departments = new List<Department>()
            {
                new Department() { Name = "Development", Description = "Development department" },
                new Department() { Name = "Business", Description = "Business department" },
                new Department() { Name = "HR", Description = "HR department" },
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();
        }
    }
}
