using HumanResourcesAPI.Data;
using HumanResourcesAPI.Models.Domain;
using HumanResourcesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesAPI.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext dbContext;

        public EmployeeRepository(AppDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        public async Task<Employee> CreateAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteAsync(Guid id)
        {
            var existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (existingEmployee is null)
            {
                return null;
            }

            dbContext.Employees.Remove(existingEmployee);
            await dbContext.SaveChangesAsync();
            return existingEmployee;
        }


        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee?> UpdateAsync(Employee employee)
        {
            var existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);

            if (existingEmployee != null)
            {
                dbContext.Entry(existingEmployee).CurrentValues.SetValues(employee);
                await dbContext.SaveChangesAsync();
                return employee;
            }

            return null;
        }




    }
}
