using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetAdminConnect.Shared.Enums;

namespace PetAdminConnect.Shared.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        
        [Display(Name = "Nombre Mascota")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Edad Mascota")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public byte Age { get; set; }

        [Display(Name = "Género Mascota")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public SharedEnums.GenderType GenderType { get; set; }

        [Display(Name = "Talla Mascota")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public SharedEnums.SizeType SizeType { get; set; }

        [Display(Name = "Género Mascota")]
        [NotMapped]
        public string GenderTypeName => SharedEnums.GenderTypeName[GenderType];

        [Display(Name = "Talla Mascota")]
        [NotMapped]
        public string SizeTypeName => SharedEnums.SizeTypeName[SizeType];

        [Display(Name = "Propietario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ClientId { get; set; }

        public Client? Client { get; set; }

        [Display(Name = "Especie")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int SpecieId { get; set; }

        public Specie? Specie { get; set; } = null!;
        
        [Display(Name = "Raza")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int BreedId { get; set; }

        public Breed? Breed { get; set; } = null!;

        public ICollection<AppointmentData>? Appointments { get; set; } = null!;
    }
}
