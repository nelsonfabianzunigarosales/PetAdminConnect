using PetAdminConnect.Backend.Data;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Repositories
{
    public class SpecialitiesRepository : GenericRepository<Speciality>
    {
        public SpecialitiesRepository(DataContext context) : base(context)
        {
        }
    }
}
