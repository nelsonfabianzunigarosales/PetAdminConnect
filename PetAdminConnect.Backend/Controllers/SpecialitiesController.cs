using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces.UnitOfWork;
using PetAdminConnect.Backend.UnitOfWork;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialitiesController : GenericController<Speciality>
    {
        private readonly ISpecialitiesUnitOfWork _specialitiesUnitOfWork;

        public SpecialitiesController(IGenericUnitOfWork<Speciality> unitOfWork, ISpecialitiesUnitOfWork specialitiesUnitOfWork) : base(unitOfWork)
        {
            _specialitiesUnitOfWork = specialitiesUnitOfWork;
        }

        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<IActionResult> GetComboAsync()
        {
            return Ok(await _specialitiesUnitOfWork.GetComboAsync());
        }
    }
}
