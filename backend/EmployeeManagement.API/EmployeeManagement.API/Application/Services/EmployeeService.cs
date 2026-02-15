using EmployeeManagement.API.Application.Interfaces;
using EmployeeManagement.API.Core.Entities;
using EmployeeManagement.API.Core.Interfaces;

namespace EmployeeManagement.API.Application.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.CreateAsync(employee);
        }

        public async Task Delete(int employeeId)
        {
            await _employeeRepository.DeleteAsync(employeeId);
        }

        public async Task<IReadOnlyList<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _employeeRepository.GetEmployeeById(employeeId);
        }

        public async Task<decimal> GetTotalSalariesAsync()
        {
            return await _employeeRepository.GetTotalSalaryForAllEmployees();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }
    }
}
