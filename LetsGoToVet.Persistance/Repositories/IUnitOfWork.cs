
using LetsGoToVet.Domain.Interfaces.Repositories;

namespace LetsGoToVet.Persistence.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        LetsGoToVetDbContext DbContext { get; }

        TRepository GetRepository<TRepository>() where TRepository : class;

        Task SaveChangesAsync();
    }
}
