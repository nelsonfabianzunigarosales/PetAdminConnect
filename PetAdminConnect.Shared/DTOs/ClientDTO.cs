namespace PetAdminConnect.Shared.DTOs
{
    public class ClientDTO : UserDTO
    {
        public int ClientId { get; set; }
        public ICollection<PetDTO>? Pets { get; set; }
    }
}
