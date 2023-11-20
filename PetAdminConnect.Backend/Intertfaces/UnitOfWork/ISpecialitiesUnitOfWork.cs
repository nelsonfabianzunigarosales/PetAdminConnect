using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Intertfaces.UnitOfWork
{
    public interface ISpecialitiesUnitOfWork
    {
        Task<IEnumerable<Speciality>> GetComboAsync();
    }
}