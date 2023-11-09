using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Backend.Repositories;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public class SpeciesUnitOfWork : GenericUnitOfWork<Specie>, ISpeciesUnitOfWork
    {
        private readonly ISpeciesRepository _especiesRepository;

        public SpeciesUnitOfWork(IGenericRepository<Specie> repository, ISpeciesRepository especiesRepository) : base(repository)
        {
            _especiesRepository = especiesRepository;
        }

        public override async Task<Response<IEnumerable<Specie>>> GetAsync(PaginationDTO pagination) => await _especiesRepository.GetAsync(pagination);

        public override async Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _especiesRepository.GetTotalPagesAsync(pagination);

        public override async Task<Response<Specie>> GetAsync(int id) => await _especiesRepository.GetAsync(id);
    }
}
