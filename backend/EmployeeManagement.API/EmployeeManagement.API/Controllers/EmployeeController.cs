using EmployeeManagement.API.Application.DTOs;
using EmployeeManagement.API.Application.Interfaces;
using EmployeeManagement.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            var employeesToSent = new List<EmployeeDto>();
            foreach (var emp in employees)
            {
                employeesToSent.Add(new EmployeeDto
                {
                    EmployeeId = emp.Id,
                    Name = emp.Name,
                    Address = emp.Address,
                    GenderName = emp.Gender.Name,
                    JobTitle = emp.Job.Title,
                    DepartmentName = emp.Job.Department.Name,
                    Salary = emp.Job.Salary
                });
            }
            return Ok(employeesToSent);
        }
        [HttpGet("{EmployeeId:int}")]
        public async Task<IActionResult> GetEmployeeByEId(int EmployeeId)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(EmployeeId);
            var employeeToSent = new EmployeeDto
            {
                EmployeeId = emp.Id,
                Name = emp.Name,
                Address = emp.Address,
                GenderId = emp.Gender.Id,
                GenderName = emp.Gender.Name,
                JobTitle = emp.Job.Title,
                DepartmentName = emp.Job.Department.Name,
                DepartmentId = emp.Job.Department.Id,
                Salary = emp.Job.Salary
            };
            return Ok(employeeToSent);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto dto)
        {
            // Map DTO => Domain
            var employee = new Employee
            {
                Name = dto.Name,
                Address = dto.Address,
                Gender = new Gender
                {
                    Id = dto.GenderId,
                    Name = dto.GenderName
                },
                Job = new EmployeeJob
                {
                    Title = dto.JobTitle,
                    Salary = dto.Salary,
                    Department = new Department
                    {
                        Id = dto.DepartmentId,
                        Name = dto.DepartmentName
                    }
                }
            };
            await _employeeService.CreateEmployeeAsync(employee);
            return Ok();
        }
        [HttpDelete("{EmployeeId:int}")]
        public async Task<IActionResult> Delete(int EmployeeId)
        {
            await _employeeService.Delete(EmployeeId);
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeDto dto)
        {
            var employee = new Employee
            {
                Id = id,
                Name = dto.Name,
                Address = dto.Address,
                Gender = new Gender
                {
                    Id = dto.GenderId,
                    Name = dto.GenderName
                },
                Job = new EmployeeJob
                {
                    Title = dto.JobTitle,
                    Salary = dto.Salary,
                    Department = new Department
                    {
                        Id = dto.DepartmentId,
                        Name = dto.DepartmentName
                    }
                }
            };
            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok();
        }
        [HttpGet("salaries/total")]
        public async Task<IActionResult> GetTotalSalaries()
        {
            var total = await _employeeService.GetTotalSalariesAsync();
            return Ok(new { totalSalary = total });
        }
    }
}
