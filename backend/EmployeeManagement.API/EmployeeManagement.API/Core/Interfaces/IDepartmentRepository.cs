using EmployeeManagement.API.Core.Entities;

namespace EmployeeManagement.API.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IReadOnlyList<Department>> GetAllAsync();
    }
}
