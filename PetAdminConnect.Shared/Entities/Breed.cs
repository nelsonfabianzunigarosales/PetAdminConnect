using System.ComponentModel.DataAnnotations;

namespace PetAdminConnect.Shared.Entities
{
    public class Breed
    {
        public int Id { get; set; }
        
        [Display(Name = "Nombre Raza")]
        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Descripcion Raza")]
        [MaxLength(150, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string? Description { get; set; }

        public int IdSpecie { get; set; }
        public Specie? Specie { get; set; }
    }
}
