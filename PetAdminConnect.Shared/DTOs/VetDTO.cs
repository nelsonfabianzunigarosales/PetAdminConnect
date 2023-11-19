namespace PetAdminConnect.Shared.DTOs
{
    public class VetDTO : UserDTO
    {
        public int VetId { get; set; }
        public ICollection<VetSpecialityDTO> VetSpecialities { get; set; } = null!;
        public ICollection<AppointmentDTO>? Appointments { get; set; }
    }
}
