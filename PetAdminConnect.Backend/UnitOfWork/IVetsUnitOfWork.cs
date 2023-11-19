using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public interface IVetsUnitOfWork
    {
        Task<Response<Vet>> GetAsync(string id);
    }
}