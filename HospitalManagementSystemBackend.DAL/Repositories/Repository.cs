
using HospitalManagementSystemBackend.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HospitalManagementSystemBackend.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HMSDbContext _context;
        private readonly ILogger<Repository<T>> _logger;

        public Repository(HMSDbContext hMSDbContext)
        {
            this._context = hMSDbContext;
        }

        public virtual async Task<T> Add(T item)
        {
            try
            {
                await _context.Set<T>().AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public virtual async Task<List<T>> Add(List<T> items)
        {
            try
            {
                foreach (var entity in items)
                {
                    await _context.Set<T>().AddAsync(entity);
                }
                await _context.SaveChangesAsync();
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public virtual async Task<T> Delete(Guid id)
        {
            try
            {
                var entity = await GetSingle(id);
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public virtual async Task<List<T>> Delete(List<T> items)
        {
            try
            {
                foreach (var item in items)
                {
                    _context.Set<T>().Remove(item);
                }
                await _context.SaveChangesAsync();
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public virtual async Task<List<T>> Get()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public virtual async Task<List<T>> Get(Func<T, bool> func)
        {
            try
            {
                return _context.Set<T>().Where(func).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public virtual async Task<T> GetSingle(Guid id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public virtual async Task<T> GetSingle(Func<T, bool> func)
        {
            try
            {
                return _context.Set<T>().Where(func).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public virtual async Task<T> Update(T item)
        {
            try
            {
                _context.Entry<T>(item).State = EntityState.Detached;
                _context.Set<T>().Update(item);
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public virtual async Task<List<T>> Update(List<T> items)
        {
            try
            {
                foreach (var item in items)
                {
                    _context.Entry<T>(item).State = EntityState.Detached;
                    _context.Set<T>().Update(item);
                    _context.Entry(item).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }
    }

}