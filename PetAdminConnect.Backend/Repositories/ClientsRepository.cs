using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Repositories
{
    public class ClientsRepository : GenericRepository<Breed>, IClientsRepository
    {
        private readonly DataContext _context;

        public ClientsRepository(DataContext context) : base(context)
        {
            _context = context;
        }        
    }
}
