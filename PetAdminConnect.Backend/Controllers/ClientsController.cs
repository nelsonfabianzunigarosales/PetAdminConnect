using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Helpers;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Backend.UnitOfWork;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

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
    }
}
