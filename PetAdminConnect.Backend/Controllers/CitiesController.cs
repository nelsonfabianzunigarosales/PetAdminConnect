using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : GenericController<City>
    {
        private readonly IGenericUnitOfWork<City> _unitOfWork;

        public CitiesController(IGenericUnitOfWork<City> unitOfWork ) : base(unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetEntityInclude(
                string.Empty,
                pagination,
                pagination.Filter == null ?
                x => x.StateId == pagination.Id :
                x => x.StateId == pagination.Id && x.Name.ToLower().Contains(pagination.Filter!),
                x => x.OrderBy(o => o.Name));

            return Ok(action.Result);
        }

        [HttpGet("totalPages")]
        public override async Task<ActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetTotalPagesAsync(pagination,
                 x => x.State!.Id == pagination.Id || x.Name.ToLower().Contains(pagination.Filter!));

            return Ok(action.Result);
        }
    }
}
