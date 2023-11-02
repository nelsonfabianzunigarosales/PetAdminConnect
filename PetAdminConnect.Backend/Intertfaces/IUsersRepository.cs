using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces
{
    public interface IUsersRepository
    {
        Task<Response<User>> GetAsync(string email);
    }

}
