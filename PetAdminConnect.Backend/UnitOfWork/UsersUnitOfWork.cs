using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public class UsersUnitOfWork : IUsersUnitOfWork
    {
        private readonly IUsersRepository _usersRepository;

        public UsersUnitOfWork(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Response<User>> GetAsync(string email) => await _usersRepository.GetAsync(email);
    }

}
