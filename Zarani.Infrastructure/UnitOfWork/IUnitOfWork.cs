using Zarani.Infrastructure.Respositories;

namespace Zarani.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAsync<T> GetRepository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
