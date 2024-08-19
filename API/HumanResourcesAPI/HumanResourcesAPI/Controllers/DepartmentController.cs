using HumanResourcesAPI.Data;
using HumanResourcesAPI.Models.Domain;
using HumanResourcesAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public DepartmentController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentRequestDto request)
        {
            
            var department = new Department
            {
                Name = request.Name,
                Location = request.Location
            };

            await dbContext.Departments.AddAsync(department);
            await dbContext.SaveChangesAsync();

            
            var response = new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Location = department.Location
            };


            return Ok(response);
        }
    }
}
