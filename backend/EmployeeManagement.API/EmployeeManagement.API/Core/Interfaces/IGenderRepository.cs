using EmployeeManagement.API.Core.Entities;

namespace EmployeeManagement.API.Core.Interfaces
{
    public interface IGenderRepository
    {
        Task<IReadOnlyList<Gender>> GetAllAsync();
    }
}
