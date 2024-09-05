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
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> GetAll() => _dbSet;

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
        {
            return includes.Aggregate(_dbSet.AsQueryable(), (current, include) => current.Include(include));
        }

        public IQueryable<T> GetThenIncluding(List<Func<IQueryable<T>, IQueryable<T>>> funcs, params Expression<Func<T, object>>[] includes)
        {
            var query = includes.Aggregate(_dbSet.AsQueryable(), (current, include) => current.Include(include));
            return funcs.Aggregate(query, (current, func) => func(current));
        }

        public IQueryable<T> IQueryable() => _dbSet;

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(List<T> entities) => await _dbSet.AddRangeAsync(entities);

        public async Task DeleteAsync(T entity)
        {
            if (entity.GetType().GetProperty("IsDelete") != null)
            {
                entity.GetType().GetProperty("IsDelete").SetValue(entity, true);
                await UpdateAsync(entity);
            }
            else
            {
                var dbEntityEntry = _dbContext.Entry(entity);
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
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? await _dbSet.AsNoTracking().ToListAsync()
                : await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbSet.AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task<T> AddAuditableAsync(T entity)
        {
            await AddAsync(entity);
            return entity;
        }
    }
}