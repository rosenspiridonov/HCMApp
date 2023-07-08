using CapitalManagement.Data;

using Microsoft.EntityFrameworkCore;

namespace CapitalManagement.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetAllNames()
            => await _context.Departments.Select(d => d.Name).ToListAsync();

        public async Task<int> GetIdAsync(string name)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Name == name);

            if (department == null)
            {
                throw new ArgumentNullException("Invalid department name");
            }

            return department.Id;
        }

        public Task CreateAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, string newName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
