using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces
{
    public interface IUsersRepository
    {
        Task<Response<User>> GetAsync(string email);

        Task<Response<IEnumerable<User>>> GetAsync(PaginationDTO pagination);

        Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination);

    }
}
