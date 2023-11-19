namespace PetAdminConnect.Shared.Entities
{
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool? IsAllDay { get; set; }
        public string CategoryColor { get; set; } = string.Empty;
        public string RecurrenceRule { get; set; } = string.Empty;
        public int? RecurrenceID { get; set; }
        public string RecurrenceException { get; set; } = string.Empty;
        public string StartTimezone { get; set; } = string.Empty;
        public string EndTimezone { get; set; } = string.Empty;
        public int ClientId { get; set; }
        public Client? Cliente { get; set; }
        public int PetId { get; set; }
        public Pet? Pet { get; set; }
        public int VetId { get; set; }
        public Vet? Vet { get; set; }
    }
}
