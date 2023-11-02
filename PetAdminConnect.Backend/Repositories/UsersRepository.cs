using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Response<User>> GetAsync(string email)
        {
            var user = await _context.Users
                .Include(u => u.City!)
                .ThenInclude(c => c.State!)
                .ThenInclude(s => s.Country)
                .FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return new Response<User>
                {
                    WasSuccess = false,
                    Message = "Usuario no encontrado"
                };
            }

            return new Response<User>
            {
                WasSuccess = true,
                Result = user
            };
        }
    }

}
