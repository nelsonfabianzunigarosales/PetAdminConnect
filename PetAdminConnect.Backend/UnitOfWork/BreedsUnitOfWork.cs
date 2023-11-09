using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Backend.Repositories;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public class BreedsUnitOfWork : GenericUnitOfWork<Breed>, IBreedsUnitOfWork
    {
        private readonly IBreedsRepository _breedsRepository;

        public BreedsUnitOfWork(IGenericRepository<Breed> repository, IBreedsRepository breedsRepository) : base(repository)
        {
            _breedsRepository = breedsRepository;
        }

        public override async Task<Response<IEnumerable<Breed>>> GetAsync(PaginationDTO pagination) => await _breedsRepository.GetAsync(pagination);

        public override async Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _breedsRepository.GetTotalPagesAsync(pagination);

        public override async Task<Response<Breed>> GetAsync(int id) => await _breedsRepository.GetAsync(id);
    }
}
