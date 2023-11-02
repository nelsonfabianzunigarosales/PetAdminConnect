using Microsoft.AspNetCore.Identity;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUsersUnitOfWork _userUnitOfWork;

        public UserHelper(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IUsersUnitOfWork userUnitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userUnitOfWork = userUnitOfWork;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            var action = await _userUnitOfWork.GetAsync(email);
            return action.Result!;
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }
    }
}
