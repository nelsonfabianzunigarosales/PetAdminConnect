using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Intertfaces;
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

        public async Task<GenericResponse<T>> AddAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new GenericResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException dbUpdateException)
            {
                return DbUpdateExceptionResponse(dbUpdateException);
            }
            catch (Exception exception)
            {
                return ExceptionResponse(exception);
            }
        }

        public async Task<GenericResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row != null)
            {
                _entity.Remove(row);
                await _context.SaveChangesAsync();
                return new GenericResponse<T>
                {
                    WasSuccess = true,
                };
            }
            return new GenericResponse<T>
            {
                WasSuccess = false,
                Message = "Registro no encontrado"
            };
        }

        public async Task<GenericResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row != null)
            {
                return new GenericResponse<T>
                {
                    WasSuccess = true,
                    Result = row
                };
            }
            return new GenericResponse<T>
            {
                WasSuccess = false,
                Message = "Registro no encontrado"
            };
        }

        public async Task<GenericResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();

            return new GenericResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await queryable
                .Paginate(pagination)
                .ToListAsync()
            };
        }

        public async Task<GenericResponse<T>> UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return new GenericResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException dbUpdateException)
            {
                return DbUpdateExceptionResponse(dbUpdateException);
            }
            catch (Exception exception)
            {
                return ExceptionResponse(exception);
            }
        }

        private GenericResponse<T> ExceptionResponse(Exception exception)
        {
            return new GenericResponse<T>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }

        private GenericResponse<T> DbUpdateExceptionResponse(DbUpdateException dbUpdateException)
        {
            if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
            {
                return new GenericResponse<T>
                {
                    WasSuccess = false,
                    Message = "Ya existe el registro que estas intentando crear."
                };
            }
            else
            {
                return new GenericResponse<T>
                {
                    WasSuccess = false,
                    Message = dbUpdateException.InnerException.Message
                };
            }
        }

        public virtual async Task<Response<int>> GetTotalPagesAsync(
            PaginationDTO pagination,
            Expression<Func<T, bool>>? filter = null)
        {
            var queryable = _entity.AsQueryable();
            
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);

            return new Response<int>
            {
                WasSuccess = true,
                Result = totalPages
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
