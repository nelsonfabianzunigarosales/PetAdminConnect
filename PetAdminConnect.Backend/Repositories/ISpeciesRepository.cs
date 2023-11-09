using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Repositories
{
    public interface ISpeciesRepository
    {
        Task<Response<Specie>> GetAsync(int id);
        Task<Response<IEnumerable<Specie>>> GetAsync(PaginationDTO pagination);
        Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}