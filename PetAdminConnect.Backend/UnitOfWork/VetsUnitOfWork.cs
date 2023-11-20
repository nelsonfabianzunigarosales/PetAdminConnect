using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Backend.Intertfaces.UnitOfWork;
using PetAdminConnect.Shared.DTOs;
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

        public async Task<Response<Vet>> AddAsync(VetDTO model) => await _vetsRepository.AddAsync(model);
        
        public async Task<Response<Vet>> GetAsync(string id) => await _vetsRepository.GetAsync(id);
    }
}
