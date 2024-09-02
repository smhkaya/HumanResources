using HumanResourcesAPI.Data;
using HumanResourcesAPI.Models.Domain;
using HumanResourcesAPI.Models.DTO;
using HumanResourcesAPI.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentRequestDto request)
        {

            var department = new Department
            {
                Name = request.Name,
                Location = request.Location
            };

            await departmentRepository.CreateAsync(department);

            var response = new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Location = department.Location
            };


            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await departmentRepository.GetAllAsync();

            var response = new List<DepartmentDto>();
            foreach (var department in departments)
            {
                response.Add(new DepartmentDto
                {
                    Id = department.Id,
                    Name = department.Name,
                    Location = department.Location
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] Guid id)
        {
            var existingDepartment = await departmentRepository.GetById(id);

            if (existingDepartment is null)
            {
                return NotFound();
            }

            var response = new DepartmentDto
            {
                Id = existingDepartment.Id,
                Name = existingDepartment.Name,
                Location = existingDepartment.Location
            };

            return Ok(response);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditDepartment([FromRoute] Guid id, UpdateDepartmentRequestDto request)
        {
            var department = new Department
            {
                Id = id,
                Name = request.Name,
                Location = request.Location
            };

            department = await departmentRepository.UpdateAsync(department);

            if (department is null)
            {
                return NotFound();
            }

            var response = new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Location = department.Location
            };
            return Ok(response);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] Guid id)
        {
            var department = await departmentRepository.DeleteAsync(id);

            if (department is null)
            {
                return NotFound();
            }

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
