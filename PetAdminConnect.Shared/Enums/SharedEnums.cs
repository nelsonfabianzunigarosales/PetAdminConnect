namespace PetAdminConnect.Shared.Enums
{
    public class SharedEnums
    {
        #region Master Enums
        public enum GenderType : byte
        {
            Female,
            Male
        }

        public enum SizeType : byte
        {
            Small,
            Medium,
            Large
        }
        #endregion

        #region Dictionaries
        public static Dictionary<GenderType, string> GenderTypeName => new()
        {
            {GenderType.Female, "Femenino" },
            {GenderType.Male, "Masculino" }
        };

        public static Dictionary<SizeType, string> SizeTypeName => new()
        {
            {SizeType.Small, "Pequeño" },
            {SizeType.Medium, "Mediano" },
            {SizeType.Large, "Grande" }
        };
        #endregion

    }
}
