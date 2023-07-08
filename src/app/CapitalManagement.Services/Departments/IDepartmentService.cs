namespace CapitalManagement.Services.Departments
{
    public interface IDepartmentService
    {
        Task<IEnumerable<string>> GetAllNamesAsync();
    }
}
