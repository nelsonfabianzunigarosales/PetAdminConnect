using System.ComponentModel.DataAnnotations;

namespace PetAdminConnect.Shared.DTOs
{
    public class VetDTO : UserDTO
    {
        public int VetId { get; set; }

        [Required(ErrorMessage = "Debes seleccionar al menos una especialidad.")]
        public ICollection<VetSpecialityDTO> VetSpecialities { get; set; } = null!;
        public ICollection<AppointmentDTO>? Appointments { get; set; }
    }
}
