using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces.UnitOfWork;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : GenericController<Client>
    {
        private readonly IGenericUnitOfWork<Client> _unitOfWork;
        private readonly IClientsUnitOfWork _clientsUnitOfWork;
        private readonly string _container;

        public ClientsController(
            IGenericUnitOfWork<Client> unitOfWork,            
            IClientsUnitOfWork clientsUnitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _clientsUnitOfWork = clientsUnitOfWork;
            _container = "users";
        }

        [HttpGet("GetClient/{userId}")]
        public async Task<IActionResult> GetClient(string userId)
        {
            var response = await _clientsUnitOfWork.GetAsync(userId);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }
    }
}
