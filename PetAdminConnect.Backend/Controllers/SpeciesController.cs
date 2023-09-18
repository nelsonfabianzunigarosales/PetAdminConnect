using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeciesController : GenericController<Specie>
    {
        public SpeciesController(IGenericUnitOfWork<Specie> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
