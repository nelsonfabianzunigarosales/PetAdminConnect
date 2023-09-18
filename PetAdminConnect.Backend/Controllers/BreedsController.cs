using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [Route("api/[controller]")]
    public class BreedsController : GenericController<Breed>
    {
        public BreedsController(IGenericUnitOfWork<Breed> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
