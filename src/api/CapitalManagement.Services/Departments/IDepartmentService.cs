namespace CapitalManagement.Services.Departments
{
    public interface IDepartmentService
    {
        Task<IEnumerable<string>> GetAllNames();

        Task<int> GetIdAsync(string name);

        Task CreateAsync(string name);

        Task UpdateAsync(int id, string newName);

        Task DeleteAsync(int id);
    }
}
