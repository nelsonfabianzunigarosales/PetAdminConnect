namespace PetAdminConnect.Shared.Entities
{
    public class VetSpeciality
    {
        public int VetId { get; set; }
        public Vet Vet { get; set; } = null!;

        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; } = null!;
    }
}
