using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Repositories
{
    public class ClientsRepository : GenericRepository<Client>, IClientsRepository
    {
        private readonly DataContext _context;

        public ClientsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Response<Client>> GetAsync(int id)
        {
            var country = await _context.Clients
                 .Include(c => c.Pets!)
                 .Include(s => s.User!)
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
            {
                return new Response<Client>
                {
                    WasSuccess = false,
                    Message = "Cliente no existe"
                };
            }

            return new Response<Client>
            {
                WasSuccess = true,
                Result = country
            };
        }
    }
}
