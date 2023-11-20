using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Repositories
{
    public class SpecialitiesRepository : GenericRepository<Speciality>, ISpecialitiesRepository
    {
        private readonly DataContext _context;

        public SpecialitiesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Speciality>> GetComboAsync()
        {
            return await _context.Specialities
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}
