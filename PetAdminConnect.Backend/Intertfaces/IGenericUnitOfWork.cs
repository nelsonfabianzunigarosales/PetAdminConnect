using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Responses;
using System.Linq.Expressions;

namespace PetAdminConnect.Backend.Intertfaces
{
    public interface IGenericUnitOfWork<T> where T : class
    {
        Task<GenericResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination);

        Task<GenericResponse<T>> AddAsync(T model);

        Task<GenericResponse<T>> UpdateAsync(T model);

        Task<GenericResponse<T>> DeleteAsync(int id);

        Task<GenericResponse<T>> GetAsync(int id);

        Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination,
            Expression<Func<T, bool>>? filter = null);

        Task<Response<ICollection<T>>> GetEntityInclude(
            string include,
            PaginationDTO? pagination,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    }
}
