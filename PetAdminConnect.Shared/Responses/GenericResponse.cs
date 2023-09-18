namespace PetAdminConnect.Shared.Responses
{
    public class GenericResponse<T>
    {
        public bool WasSuccess { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }

}
