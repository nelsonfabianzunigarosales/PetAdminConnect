using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Backend.Repositories;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public class VetsUnitOfWork : GenericUnitOfWork<Vet>, IVetsUnitOfWork
    {
        private readonly IVetsRepository _vetsRepository;

        public VetsUnitOfWork(IGenericRepository<Vet> repository, IVetsRepository vetsRepository) : base(repository)
        {
            _vetsRepository = vetsRepository;
        }

        public async Task<Response<Vet>> GetAsync(string id) => await _vetsRepository.GetAsync(id);
    }
}
