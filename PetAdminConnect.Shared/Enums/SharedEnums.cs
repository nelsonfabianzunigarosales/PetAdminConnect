using System.ComponentModel;

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

        public enum UserType
        {
            Admin,

            User,

            Vet
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

        public static Dictionary<UserType, string> UserTypeName => new()
        {
            {UserType.Admin, "Administrador" },
            {UserType.User, "Usuario" },
            {UserType.Vet, "Veterinario" }
        };





        #endregion

    }
}
