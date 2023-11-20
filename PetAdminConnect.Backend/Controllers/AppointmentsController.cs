using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetAdminConnect.Backend.Intertfaces.UnitOfWork;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : GenericController<AppointmentData>
    {
        public AppointmentsController(IGenericUnitOfWork<AppointmentData> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
