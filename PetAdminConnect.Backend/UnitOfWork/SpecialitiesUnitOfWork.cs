using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Backend.Intertfaces.UnitOfWork;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.UnitOfWork
{
    public class SpecialitiesUnitOfWork : GenericUnitOfWork<Speciality>, ISpecialitiesUnitOfWork
    {
        private readonly ISpecialitiesRepository _specialitiesRepository;

        public SpecialitiesUnitOfWork(IGenericRepository<Speciality> repository, ISpecialitiesRepository specialitiesRepository) : base(repository)
        {
            _specialitiesRepository = specialitiesRepository;
        }

        public async Task<IEnumerable<Speciality>> GetComboAsync() => await _specialitiesRepository.GetComboAsync();
    }
}
