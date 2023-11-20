using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Backend.Intertfaces.UnitOfWork;
using PetAdminConnect.Backend.Repositories;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public class AppointmentsUnitOfWork : GenericUnitOfWork<AppointmentData>, IAppointmentsUnitOfWork
    {
        private readonly IAppointmentsRepository _appointmentsRepository;

        public AppointmentsUnitOfWork(IGenericRepository<AppointmentData> repository, IAppointmentsRepository appointmentsRepository) : base(repository)
        {
            _appointmentsRepository = appointmentsRepository;
        }
    }
}
