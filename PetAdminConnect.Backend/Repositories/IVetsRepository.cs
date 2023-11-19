using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Repositories
{
    public interface IVetsRepository
    {
        Task<Response<Vet>> GetAsync(string id);
    }
}