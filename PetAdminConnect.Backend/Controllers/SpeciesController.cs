using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class SpeciesController : GenericController<Specie>
    {
        private readonly IGenericUnitOfWork<Specie> _unitOfWork;

        public SpeciesController(IGenericUnitOfWork<Specie> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetEntityInclude(
                "Breeds", 
                pagination,
                string.IsNullOrEmpty(pagination.Filter) ? null : x => x.Name.ToLower().Contains(pagination.Filter!),
                x => x.OrderBy(o => o.Name));

            return Ok(action.Result);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetEntityInclude("Breeds", null, x => x.Id == id, null);
            var specie = action.Result!.FirstOrDefault();

            if (specie == null)
            {
                return NotFound();
            }

            return Ok(specie);
        }
    }
}
