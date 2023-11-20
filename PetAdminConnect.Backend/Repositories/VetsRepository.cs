using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Shared.DTOs;
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

        public async Task<Response<Vet>> AddAsync(VetDTO entity)
        {
            var vet = new Vet()
            {
                User = entity
            };

            var vetSpecialities = entity.VetSpecialities.Select(specialityId => new VetSpeciality
            {
                Vet = vet,
                SpecialityId = specialityId.SpecialityId
            }).ToList();

            // Asigna las nuevas instancias de VetSpeciality a la colección VetEspecialities del veterinario
            vet.VetEspecialities = vetSpecialities;

            // Agrega el veterinario y sus especialidades a la base de datos
            _context.Vets.Add(vet);
            await _context.SaveChangesAsync();

            return new Response<Vet>
            {
                WasSuccess = true,
                Result = vet
            };
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
                    Message = "Veterinario no existe"
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
