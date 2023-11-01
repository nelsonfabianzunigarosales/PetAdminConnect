using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [Route("api/[controller]")]
    public class BreedsController : GenericController<Breed>
    {
        private readonly IGenericUnitOfWork<Breed> _unitOfWork;

        public BreedsController(IGenericUnitOfWork<Breed> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetEntityInclude(
                string.Empty, 
                pagination, 
                x => x.SpecieId == pagination.Id || x.Name.ToLower().Contains(pagination.Filter!), 
                x => x.OrderBy(o => o.Name));

            return Ok(action.Result);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetEntityInclude("Specie", null, x => x.Id == id, null);
            var breed = action.Result!.FirstOrDefault();

            if (breed == null)
            {
                return NotFound();
            }

            return Ok(breed);
        }

        [HttpGet("totalPages")]
        public override async Task<ActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetTotalPagesAsync(pagination,
                x => x.SpecieId == pagination.Id || x.Name.ToLower().Contains(pagination.Filter!));

            return Ok(action.Result);
        }
    }
}
