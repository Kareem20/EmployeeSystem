using EmployeeManagement.API.Application.Interfaces;
using EmployeeManagement.API.Core.Entities;
using EmployeeManagement.API.Core.Interfaces;

namespace EmployeeManagement.API.Application.Implementations
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<IReadOnlyList<Gender>> GetAllGendersAsync()
        {
            return await _genderRepository.GetAllAsync();
        }
    }
}
