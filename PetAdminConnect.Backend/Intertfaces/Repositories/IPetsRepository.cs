using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces.Repositories
{
    public interface IPetsRepository
    {
        Task<Response<IEnumerable<Pet>>> GetAsync(PaginationDTO pagination);
    }
}