using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public interface IClientsUnitOfWork
    {
        Task<Response<Client>> GetAsync(string id);
    }
}