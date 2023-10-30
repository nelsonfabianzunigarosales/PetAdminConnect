using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Helpers;

namespace PetAdminConnect.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : GenericController<State>
    {
        private readonly IGenericUnitOfWork<State> _unitOfWork;

        public StatesController(IGenericUnitOfWork<State> unitOfWork) 
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetEntityInclude(
                "Cities", 
                pagination, 
                x => x.CountryId == pagination.Id, 
                x => x.OrderBy(o => o.Name));

            return Ok(action.Result);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetEntityInclude(
               "Cities",
               null,
               x => x.Id == id,
               null);

            var state = action.Result!.FirstOrDefault();
            
            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        [HttpGet("totalPages")]
        public override async Task<ActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetTotalPagesAsync(pagination, 
                x => x.CountryId == pagination.Id);
            
            return Ok(action.Result);
        }
    }
}
