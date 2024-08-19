using HumanResourcesAPI.Data;
using HumanResourcesAPI.Models.Domain;
using HumanResourcesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesAPI.Repositories.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Department> CreateAsync(Department department)
        {
            await dbContext.Departments.AddAsync(department);
            await dbContext.SaveChangesAsync();

            return department;
        }
    }
}
