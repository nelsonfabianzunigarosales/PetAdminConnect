using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : GenericController<Country>
    {
        private readonly IGenericUnitOfWork<Country> _unitOfWork;

        public CountriesController(IGenericUnitOfWork<Country> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetEntityInclude(
                "States", 
                pagination, 
                string.IsNullOrEmpty(pagination.Filter) ? null : x => x.Name.ToLower().Contains(pagination.Filter!), 
                x => x.OrderBy(o => o.Name));

            return Ok(action.Result);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetEntityInclude("States, States.Cities", null, x => x.Id == id, null);
            var country = action.Result!.FirstOrDefault();

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);           
        }

        [HttpGet("totalPages")]
        public override async Task<ActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetTotalPagesAsync(pagination,
               string.IsNullOrEmpty(pagination.Filter) ? null : x => x.Name.ToLower().Contains(pagination.Filter!));

            return Ok(action.Result);
        }
    }
}