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

        public async Task<Department?> DeleteAsync(Guid id)
        {
            var existingDepartment = await dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);

            if (existingDepartment is null)
            {
                return null;
            }

            dbContext.Departments.Remove(existingDepartment);
            await dbContext.SaveChangesAsync();
            return existingDepartment;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await dbContext.Departments.ToListAsync();
        }

        public async Task<Department?> GetById(Guid id)
        {
            return await dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Department?> UpdateAsync(Department department)
        {
            var existingDepartment = await dbContext.Departments.FirstOrDefaultAsync(x =>x.Id == department.Id);

            if (existingDepartment != null) {
                dbContext.Entry(existingDepartment).CurrentValues.SetValues(department);
                await dbContext.SaveChangesAsync();
                return department;
            }
            return null;
        }
            
    }
}
