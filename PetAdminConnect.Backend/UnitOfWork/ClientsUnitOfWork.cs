using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Backend.Repositories;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public class ClientsUnitOfWork : GenericUnitOfWork<Client>, IClientsUnitOfWork
    {
        private readonly IGenericRepository<Client> _repository;
        private readonly IClientsRepository _clientsRepository;

        public ClientsUnitOfWork(IGenericRepository<Client> repository, IClientsRepository clientsRepository) : base(repository)
        {
            _repository = repository;
            _clientsRepository = clientsRepository;
        }

        public async Task<Response<Client>> GetAsync(string id) => await _clientsRepository.GetAsync(id);

    }
}
