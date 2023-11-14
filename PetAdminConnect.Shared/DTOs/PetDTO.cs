using PetAdminConnect.Shared.Enums;

namespace PetAdminConnect.Shared.DTOs
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte Age { get; set; }
        public SharedEnums.GenderType GenderType { get; set; }
        public SharedEnums.SizeType SizeType { get; set; }
        public int SpecieId { get; set; }
        public int BreedId { get; set; }
    }
}
