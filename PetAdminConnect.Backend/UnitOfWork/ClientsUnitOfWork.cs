using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public class ClientsUnitOfWork : GenericUnitOfWork<Client>, IClientsUnitOfWork
    {
        public ClientsUnitOfWork(IGenericRepository<Client> repository) : base(repository)
        {
        }
    }
}
