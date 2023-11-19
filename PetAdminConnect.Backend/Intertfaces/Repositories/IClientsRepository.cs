using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces.Repositories
{
    public interface IClientsRepository
    {
        Task<Response<Client>> GetAsync(string id);
    }
}