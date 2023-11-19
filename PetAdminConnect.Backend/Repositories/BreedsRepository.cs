using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Helpers;
using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Repositories
{
    public class BreedsRepository : GenericRepository<Breed>, IBreedsRepository
    {
        private readonly DataContext _context;
        public BreedsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Response<IEnumerable<Breed>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Breeds
                .Where(x => x.SpecieId == pagination.Id)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new Response<IEnumerable<Breed>>
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
            var queryable = _context.Breeds
                .Where(x => x.SpecieId == pagination.Id)
                .AsQueryable();

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

        public override async Task<Response<Breed>> GetAsync(int id)
        {
            var breed = await _context.Breeds
                 .Include(c => c.Specie!)
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (breed == null)
            {
                return new Response<Breed>
                {
                    WasSuccess = false,
                    Message = "Raza no existe"
                };
            }

            return new Response<Breed>
            {
                WasSuccess = true,
                Result = breed
            };
        }

        public async Task<IEnumerable<Breed>> GetComboAsync(int specieId)
        {
            return await _context.Breeds
                .Where(s => s.SpecieId == specieId)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }
    }
}
