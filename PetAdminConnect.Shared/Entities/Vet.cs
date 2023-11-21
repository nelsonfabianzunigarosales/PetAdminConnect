namespace PetAdminConnect.Shared.Entities
{
    public class Vet
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public ICollection<VetSpeciality>? VetSpecialities { get; set; } = null!;
        public ICollection<AppointmentData>? Appointments { get; set; } = null!;
    }
}
