using EmployeeManagement.API.Application.Interfaces;
using EmployeeManagement.API.Core.Entities;
using EmployeeManagement.API.Core.Interfaces;

namespace EmployeeManagement.API.Application.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IReadOnlyList<Department>> GetAllDepartmentAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }
    }
}
