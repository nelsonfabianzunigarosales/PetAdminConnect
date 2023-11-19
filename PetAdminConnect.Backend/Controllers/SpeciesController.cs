using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Backend.UnitOfWork;
using PetAdminConnect.Backend.UnitsOfWork;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class SpeciesController : GenericController<Specie>
    {
        private readonly ISpeciesUnitOfWork _speciesUnitOfWork;

        public SpeciesController(IGenericUnitOfWork<Specie> unitOfWork, ISpeciesUnitOfWork breedsUnitOfWork) : base(unitOfWork)
        {
            _speciesUnitOfWork = breedsUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _speciesUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _speciesUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _speciesUnitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<IActionResult> GetComboAsync()
        {
            return Ok(await _speciesUnitOfWork.GetComboAsync());
        }
    }
}
