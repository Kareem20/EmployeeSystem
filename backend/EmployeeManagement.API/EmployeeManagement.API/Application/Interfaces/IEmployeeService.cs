using EmployeeManagement.API.Core.Entities;

namespace EmployeeManagement.API.Application.Interfaces
{
    public interface IEmployeeService
    {
        public Task CreateEmployeeAsync(Employee employee);
        public Task<Employee> GetEmployeeByIdAsync(int employeeId);
        public Task<IReadOnlyList<Employee>> GetAllEmployeesAsync();
        public Task UpdateEmployeeAsync(Employee employee);
        public Task Delete(int employeeId);
        public Task<decimal> GetTotalSalariesAsync();
    }
}
