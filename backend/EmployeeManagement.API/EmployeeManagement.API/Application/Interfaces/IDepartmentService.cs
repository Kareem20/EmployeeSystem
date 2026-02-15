using EmployeeManagement.API.Core.Entities;

namespace EmployeeManagement.API.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IReadOnlyList<Department>> GetAllDepartmentAsync();
    }
}
