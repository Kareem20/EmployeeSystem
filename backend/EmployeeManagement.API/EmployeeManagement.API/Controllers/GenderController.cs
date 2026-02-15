using EmployeeManagement.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genders = await _genderService.GetAllGendersAsync();
            return Ok(genders);
        }
    }
}
