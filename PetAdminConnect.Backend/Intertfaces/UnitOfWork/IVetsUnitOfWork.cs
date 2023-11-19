using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces.UnitOfWork
{
    public interface IVetsUnitOfWork
    {
        Task<Response<Vet>> GetAsync(string id);
    }
}