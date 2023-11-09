using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Helpers;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Repositories
{
    public class SpeciesRepository : GenericRepository<Specie>, ISpeciesRepository
    {
        private readonly DataContext _context;
        public SpeciesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Response<IEnumerable<Specie>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Species
                .Include(x => x.Breeds)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new Response<IEnumerable<Specie>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(c => c.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _context.Species.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);
            return new Response<int>
            {
                WasSuccess = true,
                Result = totalPages
            };
        }

        public override async Task<Response<Specie>> GetAsync(int id)
        {
            var breed = await _context.Species
                 .Include(c => c.Breeds!)
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (breed == null)
            {
                return new Response<Specie>
                {
                    WasSuccess = false,
                    Message = "Especie no existe"
                };
            }

            return new Response<Specie>
            {
                WasSuccess = true,
                Result = breed
            };
        }
    }
}
