using EmployeeManagement.API.Core.Entities;

namespace EmployeeManagement.API.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task CreateAsync(Employee employee);
        public Task<Employee> GetEmployeeById(int employeeId);
        public Task<IReadOnlyList<Employee>> GetAllAsync();
        public Task UpdateAsync(Employee employee);
        public Task DeleteAsync(int employeeId);
        public Task<decimal> GetTotalSalaryForAllEmployees();
    }
}
