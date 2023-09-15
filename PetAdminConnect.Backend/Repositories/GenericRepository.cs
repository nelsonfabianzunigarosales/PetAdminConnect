using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Data;
using PetAdminConnect.Backend.Intertfaces;
using PetAdminConnect.Shared.Responses;

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

        public async Task<GenericResponse<IEnumerable<T>>> GetAsync()
        {
            return new GenericResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await _entity.ToListAsync()
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
    }
}
