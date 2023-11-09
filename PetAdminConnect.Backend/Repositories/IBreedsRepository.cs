using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Repositories
{
    public interface IBreedsRepository
    {
        Task<Response<Breed>> GetAsync(int id);
        Task<Response<IEnumerable<Breed>>> GetAsync(PaginationDTO pagination);
        Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}