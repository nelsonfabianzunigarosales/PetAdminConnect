using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Backend.UnitOfWork;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetsController : GenericController<Vet>
    {
        private readonly IVetsUnitOfWork _vetsUnitOfWork;

        public VetsController(IGenericUnitOfWork<Vet> unitOfWork, IVetsUnitOfWork vetsUnitOfWork) : base(unitOfWork)
        {
            _vetsUnitOfWork = vetsUnitOfWork;
        }

        [HttpGet("GetVet/{userId}")]
        public async Task<IActionResult> GetClient(string userId)
        {
            var response = await _vetsUnitOfWork.GetAsync(userId);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }
    }
}
