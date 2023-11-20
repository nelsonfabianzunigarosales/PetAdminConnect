using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Repositories
{
    public class AppointmentsRepository : GenericRepository<AppointmentData>, IAppointmentsRepository
    {
        private readonly DataContext _context;

        public AppointmentsRepository(DataContext context) : base(context)
        {
            _context = context;
        }        
    }
}
