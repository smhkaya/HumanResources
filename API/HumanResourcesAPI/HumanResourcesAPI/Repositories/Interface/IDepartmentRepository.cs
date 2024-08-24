using HumanResourcesAPI.Models.Domain;

namespace HumanResourcesAPI.Repositories.Interface
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateAsync(Department department);

        Task <IEnumerable<Department>> GetAllAsync();
    }
}
