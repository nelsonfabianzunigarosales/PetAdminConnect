using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces
{
    public interface IGenericUnitOfWork<T> where T : class
    {
        Task<GenericResponse<IEnumerable<T>>> GetAsync();

        Task<GenericResponse<T>> AddAsync(T model);

        Task<GenericResponse<T>> UpdateAsync(T model);

        Task<GenericResponse<T>> DeleteAsync(int id);

        Task<GenericResponse<T>> GetAsync(int id);
    }
}
