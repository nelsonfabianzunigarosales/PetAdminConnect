using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Backend.Migrations;
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

        public async Task<Response<Client>> GetAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            var client = await _context.Clients
                 .Include(c => c.Pets!)
                 .Include(s => s.User!)
                 .FirstOrDefaultAsync(c => c.User.Id == user!.Id);

            if (client == null)
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
                Result = client
            };
        }
    }
}
