using HumanResourcesAPI.Models.Domain;
using HumanResourcesAPI.Models.DTO;
using HumanResourcesAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) 
        {
            this.employeeRepository = employeeRepository;
       
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequestDto request)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                HireDate = request.HireDate,
                JobTitle = request.JobTitle,
                PhoneNumber = request.PhoneNumber,
                Salary = request.Salary,

            };

            employee = await employeeRepository.CreateAsync(employee);

            var response = new EmployeeDto
            {
                Id = employee.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                HireDate = request.HireDate,
                JobTitle = request.JobTitle,
                PhoneNumber = request.PhoneNumber,
                Salary = request.Salary,

            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await employeeRepository.GetAllAsync();

            var response = new List<EmployeeDto>();
            foreach(var employee in employees)
            {
                response.Add(new EmployeeDto
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    HireDate = employee.HireDate,
                    JobTitle = employee.JobTitle,
                    PhoneNumber = employee.PhoneNumber,
                    Salary = employee.Salary,

                });               
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
        {
            var existingEmployee = await employeeRepository.GetByIdAsync(id);

            if (existingEmployee is null)
            {
                return NotFound();
            }

            var response = new EmployeeDto
            {
                Id = existingEmployee.Id,
                FirstName = existingEmployee.FirstName,
                LastName = existingEmployee.LastName,
                Email = existingEmployee.Email,
                HireDate = existingEmployee.HireDate,
                JobTitle = existingEmployee.JobTitle,
                PhoneNumber = existingEmployee.PhoneNumber,
                Salary = existingEmployee.Salary
            };

            return Ok(response);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditEmployee([FromRoute] Guid id, [FromBody] UpdateEmployeeRequestDto request)
        {
            var employee = new Employee
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                HireDate = request.HireDate,
                JobTitle = request.JobTitle,
                PhoneNumber = request.PhoneNumber,
                Salary = request.Salary
            };

            employee = await employeeRepository.UpdateAsync(employee);

            if (employee is null)
            {
                return NotFound();
            }

            var response = new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                HireDate = employee.HireDate,
                JobTitle = employee.JobTitle,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await employeeRepository.DeleteAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            var response = new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                HireDate = employee.HireDate,
                JobTitle = employee.JobTitle,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary
            };

            return Ok(response);
        }



    }




}



