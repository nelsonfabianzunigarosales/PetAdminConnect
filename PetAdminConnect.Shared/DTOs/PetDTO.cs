using PetAdminConnect.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetAdminConnect.Shared.DTOs
{
    public class PetDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, 100, ErrorMessage = "La edad debe ser mayor que cero.")]
        public int Age { get; set; }

        [Display(Name = "Género")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public SharedEnums.GenderType GenderType { get; set; }

        [Display(Name = "Talla")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public SharedEnums.SizeType SizeType { get; set; }

        [Display(Name = "Especie")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int SpecieId { get; set; }

        [Display(Name = "Raza")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int BreedId { get; set; }

        [Display(Name = "Propietario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ClientId { get; set; }

        [Display(Name = "Foto")]
        public string? Photo { get; set; }
    }
}
