using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Helpers;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Repositories
{
    public class PetsRepository : GenericRepository<Pet>, IPetsRepository
    {
        private readonly DataContext _context;

        public PetsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Response<IEnumerable<Pet>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Pets
                .Include(p => p.Specie)
                .Include(p => p.Breed)
                 .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            if (pagination.Id > 0)
            {
                queryable = queryable.Where(x => x.ClientId == pagination.Id);
            }

            return new Response<IEnumerable<Pet>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(c => c.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }
    }
}
