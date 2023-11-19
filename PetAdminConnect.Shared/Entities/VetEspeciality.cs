namespace PetAdminConnect.Shared.Entities
{
    public class VetEspeciality
    {
        public int VetId { get; set; }
        public Vet Vet { get; set; }

        public int EspecialityId { get; set; }
        public Especiality Especiality { get; set; }
    }
}
