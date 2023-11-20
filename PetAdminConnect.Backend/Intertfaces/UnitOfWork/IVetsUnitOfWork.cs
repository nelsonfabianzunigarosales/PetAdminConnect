using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces.UnitOfWork
{
    public interface IVetsUnitOfWork
    {
        Task<Response<Vet>> AddAsync(VetDTO model);
        Task<Response<Vet>> GetAsync(string id);
    }
}