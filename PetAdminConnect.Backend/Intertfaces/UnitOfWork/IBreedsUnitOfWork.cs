using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces.UnitOfWork
{
    public interface IBreedsUnitOfWork
    {
        Task<Response<Breed>> GetAsync(int id);
        Task<Response<IEnumerable<Breed>>> GetAsync(PaginationDTO pagination);
        Task<IEnumerable<Breed>> GetComboAsync(int specieId);
        Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}