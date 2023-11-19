using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Helpers;
using PetAdminConnect.Shared.Responses;
using System.Linq.Expressions;

namespace PetAdminConnect.Backend.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public virtual async Task<Response<T>> AddAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new Response<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionResponse(exception);
            }
        }

        public virtual async Task<Response<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new Response<T>
                {
                    WasSuccess = false,
                    Message = "Registro no encontrado"
                };
            }

            try
            {
                _entity.Remove(row);
                await _context.SaveChangesAsync();
                return new Response<T>
                {
                    WasSuccess = true,
                };
            }
            catch
            {
                return new Response<T>
                {
                    WasSuccess = false,
                    Message = "No se puede borrar, porque tiene registros relacionados"
                };
            }
        }

        public virtual async Task<Response<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row != null)
            {
                return new Response<T>
                {
                    WasSuccess = true,
                    Result = row
                };
            }
            return new Response<T>
            {
                WasSuccess = false,
                Message = "Registro no encontrado"
            };
        }

        public virtual async Task<Response<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();
            return new Response<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await queryable
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public virtual async Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();
            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);
            return new Response<int>
            {
                WasSuccess = true,
                Result = totalPages
            };
        }

        public virtual async Task<Response<T>> UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return new Response<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionResponse(exception);
            }
        }

        private Response<T> ExceptionResponse(Exception exception)
        {
            return new Response<T>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }

        private Response<T> DbUpdateExceptionResponse()
        {
            return new Response<T>
            {
                WasSuccess = false,
                Message = "Ya existe el registro que estas intentando crear."
            };
        }

        public virtual async Task<Response<ICollection<T>>> GetEntityInclude(
            string? include,
            PaginationDTO? pagination,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            var query = _entity.AsQueryable();

            if (!string.IsNullOrEmpty(include))
            {
                query = include
               .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Aggregate(query, (current, includeProperty) => current
               .Include(includeProperty.Trim()));
            }

            if (filter != null)
            {
                query = query!.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy?.Invoke(query);
            }

            if (pagination != null)
            {
                query = query!.Paginate(pagination);
            }

            return new Response<ICollection<T>>
            {
                WasSuccess = true,
                Result = await query!.AsQueryable().ToListAsync()
            };
        }
    }
}
