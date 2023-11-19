using System.ComponentModel.DataAnnotations;

namespace PetAdminConnect.Shared.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        [Display(Name = "Asunto")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Subject { get; set; } = null!;
        public string? Location { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [Display(Name = "Fecha Fin")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }

        [Display(Name = "Cliente")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int ClientId { get; set; }
        
        [Display(Name = "Mascota")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int PetId { get; set; }

        [Display(Name = "Veterinario")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int VetId { get; set; }
    }
}
