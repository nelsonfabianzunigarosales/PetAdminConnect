using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Responses;
using System.Linq.Expressions;

namespace PetAdminConnect.Backend.Intertfaces
{
    public interface IGenericUnitOfWork<T> where T : class
    {
        Task<Response<IEnumerable<T>>> GetAsync(PaginationDTO pagination);

        Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination);

        Task<Response<T>> AddAsync(T model);

        Task<Response<T>> UpdateAsync(T model);

        Task<Response<T>> DeleteAsync(int id);

        Task<Response<T>> GetAsync(int id);

        Task<Response<ICollection<T>>> GetEntityInclude(
            string include,
            PaginationDTO? pagination,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    }
}
