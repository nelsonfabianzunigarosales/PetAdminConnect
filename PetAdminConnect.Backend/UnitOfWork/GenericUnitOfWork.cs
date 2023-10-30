using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Responses;
using System.Linq.Expressions;

namespace Sales.Backend.UnitsOfWork
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericUnitOfWork(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<GenericResponse<T>> AddAsync(T model) => await _repository.AddAsync(model);

        public async Task<GenericResponse<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<GenericResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination) => await _repository.GetAsync(pagination);

        public async Task<GenericResponse<T>> GetAsync(int id) => await _repository.GetAsync(id);

        public async Task<GenericResponse<T>> UpdateAsync(T model) => await _repository.UpdateAsync(model);

        public virtual async Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination, 
            Expression<Func<T, bool>>? filter = null) => await _repository.GetTotalPagesAsync(pagination, filter);

        public virtual async Task<Response<ICollection<T>>> GetEntityInclude(
            string include, 
            PaginationDTO? pagination, 
            Expression<Func<T, bool>>? filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null) => await _repository.GetEntityInclude(
                include,
                pagination,
                filter,
                orderBy);
    }
}