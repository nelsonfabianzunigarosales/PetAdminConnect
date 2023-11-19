using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces.UnitOfWork;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialitiesController : GenericController<Speciality>
    {
        public SpecialitiesController(IGenericUnitOfWork<Speciality> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
