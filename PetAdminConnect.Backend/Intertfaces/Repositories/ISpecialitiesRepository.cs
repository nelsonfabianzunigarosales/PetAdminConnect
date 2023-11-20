using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Intertfaces.Repositories
{
    public interface ISpecialitiesRepository
    {
        Task<IEnumerable<Speciality>> GetComboAsync();
    }
}