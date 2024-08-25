using HumanResourcesAPI.Models.Domain;

namespace HumanResourcesAPI.Repositories.Interface
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateAsync(Department department);

        Task <IEnumerable<Department>> GetAllAsync();

        Task<Department?> GetById(Guid id);

        Task<Department?> UpdateAsync(Department department);

        Task<Department?> DeleteAsync(Guid id);



    }
}
