using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Responses;
using System.Linq.Expressions;

namespace PetAdminConnect.Backend.Intertfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<GenericResponse<T>> GetAsync(int id);

        Task<GenericResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination);

        Task<GenericResponse<T>> AddAsync(T entity);

        Task<GenericResponse<T>> DeleteAsync(int id);

        Task<GenericResponse<T>> UpdateAsync(T entity);

        Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination,
            Expression<Func<T, bool>>? filter = null);

        Task<Response<ICollection<T>>> GetEntityInclude(
            string include, 
            PaginationDTO? pagination, 
            Expression<Func<T, bool>>? filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

    }
}