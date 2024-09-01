using HumanResourcesAPI.Models.Domain;

namespace HumanResourcesAPI.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);

        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(Guid id);

        Task<Employee?> DeleteAsync(Guid id);

        Task<Employee?> UpdateAsync(Employee employee);
    }
}
