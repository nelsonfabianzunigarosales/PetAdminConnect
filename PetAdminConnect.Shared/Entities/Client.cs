
namespace PetAdminConnect.Shared.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Pet> Pets { get; set; } = null!;
    }
}
