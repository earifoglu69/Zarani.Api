using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Zarani.Infrastructure.Context;

namespace Zarani.Infrastructure.Respositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ZaraniDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        
        public RepositoryAsync(ZaraniDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        
        //public IQueryable<T> Entities => _dbContext.Set<T>();

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }


        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public IQueryable<T> GetThenIncluding(List<Func<IQueryable<T>, IQueryable<T>>> funcs, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            foreach (var func in funcs)
            {
                query = func(query);
            }
            return query;
        }

        public IQueryable<T> IQueryable()
        {
            IQueryable<T> query = _dbSet;
            return query;
        }

        //public IEnumerable<T> GetThenIncluding(Func<IQueryable<T>, IQueryable<T>> func)
        //{
        //    IQueryable<T> query = _dbSet;
        //    IQueryable<T> result = func(query);
        //    return result;
        //}

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(List<T> entity)
        {
            await _dbContext.Set<T>().AddRangeAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {

            if (entity.GetType().GetProperty("IsDelete") != null)
            {
                T _entity = entity;

                _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                this.UpdateAsync(_entity);
            }
            else
            {
                // Önce entity'nin state'ini kontrol etmeliyiz.
                EntityEntry dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
            }
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? await _dbContext.Set<T>().AsNoTracking().ToListAsync() : await _dbContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }

        public async Task<T> AddAuditableAsync(T entity)
        {
            /*
            if (typeof(IAuditableBaseEntity).IsAssignableFrom(typeof(T)))
            {
                IAuditableBaseEntity _entity = (IAuditableBaseEntity)entity;

                _entity.IsDeleted = true;
                _entity.LastModifiedOn = null;
                _entity.LastModifiedBy = null;
                _entity.CreatedOn = DateTime.Now;
                _entity.CreatedBy = string.Empty;

                await this.AddAsync((T)_entity);
                return (T)_entity;
            }
            else
            {
            */
            await this.AddAsync(entity);
            return entity;
            //  }

        }
    }
}
