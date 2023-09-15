using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<GenericResponse<T>> GetAsync(int id);

        Task<GenericResponse<IEnumerable<T>>> GetAsync();

        Task<GenericResponse<T>> AddAsync(T entity);

        Task<GenericResponse<T>> DeleteAsync(int id);

        Task<GenericResponse<T>> UpdateAsync(T entity);
    }
}