using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces.Repositories
{
    public interface IVetsRepository
    {
        Task<Response<Vet>> AddAsync(VetDTO entity);
        Task<Response<Vet>> GetAsync(string id);
    }
}