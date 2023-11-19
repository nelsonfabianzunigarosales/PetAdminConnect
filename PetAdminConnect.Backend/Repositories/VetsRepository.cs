using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Repositories
{
    public class VetsRepository : GenericRepository<Vet>, IVetsRepository
    {
        private readonly DataContext _context;

        public VetsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Response<Vet>> GetAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            var vet = await _context.Vets
                 .Include(c => c.VetEspecialities!)
                 .Include(s => s.Appointments!)
                 .FirstOrDefaultAsync(c => c.User.Id == user!.Id);

            if (vet == null)
            {
                return new Response<Vet>
                {
                    WasSuccess = false,
                    Message = "Cliente no existe"
                };
            }

            return new Response<Vet>
            {
                WasSuccess = true,
                Result = vet
            };
        }
    }
}
