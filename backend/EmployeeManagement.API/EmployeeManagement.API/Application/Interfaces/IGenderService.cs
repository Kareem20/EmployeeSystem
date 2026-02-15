using EmployeeManagement.API.Core.Entities;

namespace EmployeeManagement.API.Application.Interfaces
{
    public interface IGenderService
    {
        Task<IReadOnlyList<Gender>> GetAllGendersAsync();
    }
}
