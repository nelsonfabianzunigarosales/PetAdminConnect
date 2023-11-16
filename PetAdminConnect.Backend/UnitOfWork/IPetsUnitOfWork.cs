using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public interface IPetsUnitOfWork
    {
        Task<Response<IEnumerable<Pet>>> GetAsync(PaginationDTO pagination);
    }
}