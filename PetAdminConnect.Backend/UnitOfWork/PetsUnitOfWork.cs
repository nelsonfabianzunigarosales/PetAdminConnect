using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Backend.Intertfaces.UnitOfWork;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public class PetsUnitOfWork : GenericUnitOfWork<Pet>, IPetsUnitOfWork
    {
        private readonly IPetsRepository _petsRepository;

        public PetsUnitOfWork(IGenericRepository<Pet> repository, IPetsRepository petsRepository) : base(repository)
        {
            _petsRepository = petsRepository;
        }

        public override Task<Response<IEnumerable<Pet>>> GetAsync(PaginationDTO pagination) => _petsRepository.GetAsync(pagination);

    }
}
