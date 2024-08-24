﻿using HumanResourcesAPI.Data;
using HumanResourcesAPI.Models.Domain;
using HumanResourcesAPI.Models.DTO;
using HumanResourcesAPI.Repositories.Interface;
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

    }
}
