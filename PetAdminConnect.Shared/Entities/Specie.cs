using System.ComponentModel.DataAnnotations;

namespace PetAdminConnect.Shared.Entities
{
    public class Specie
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Especie")]
        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Descripcion Especie")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string? Description { get; set; }

        public ICollection<Breed>? Breeds { get; set; }
    }
}
