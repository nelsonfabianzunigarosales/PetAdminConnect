

namespace PetAdminConnect.Shared.DTOs
{
    public class ClientDTO : UserDTO
    {
        public ICollection<PetDTO>? Pets { get; set; }
    }
}
