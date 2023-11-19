using System.ComponentModel.DataAnnotations;

namespace PetAdminConnect.Shared.Entities
{
    public class AppointmentData
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Asunto")]
        public string Subject { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Ubicación")]
        public string Location { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Descripción")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Hora de inicio")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Hora de fin")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Todo el día")]
        public bool? IsAllDay { get; set; }

        [Display(Name = "Color de categoría")]
        public string CategoryColor { get; set; } = string.Empty;

        [Display(Name = "Regla de recurrencia")]
        public string RecurrenceRule { get; set; } = string.Empty;

        public int? RecurrenceID { get; set; }

        [Display(Name = "Excepción de recurrencia")]
        public string RecurrenceException { get; set; } = string.Empty;

        [Display(Name = "Zona horaria de inicio")]
        public string StartTimezone { get; set; } = string.Empty;

        [Display(Name = "Zona horaria de fin")]
        public string EndTimezone { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Cliente")]
        public int ClientId { get; set; }
        
        public Client? Client { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Mascota")]
        public int PetId { get; set; }
        
        public Pet? Pet { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Veterinario")]
        public int VetId { get; set; }

        public Vet? Vet { get; set; }
    }
}
