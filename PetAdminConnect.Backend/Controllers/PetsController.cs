using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : GenericController<Pet>
    {
        public PetsController(IGenericUnitOfWork<Pet> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
