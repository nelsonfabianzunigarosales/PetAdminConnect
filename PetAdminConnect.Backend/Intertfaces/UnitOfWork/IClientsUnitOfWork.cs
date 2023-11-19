using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces.UnitOfWork
{
    public interface IClientsUnitOfWork
    {
        Task<Response<Client>> GetAsync(string id);
    }
}