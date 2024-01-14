using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Domain;

namespace Ecommerce.Application;
public interface IUnitOfWork : IAsyncDisposable
{

    IReadRepository<T> GetReadRepository<T>() where T: class, IEntityBase, new();
    IWriteRepository<T> GetWriteRepository<T>() where T: class, IEntityBase, new();

    Task<int> SaveAsync();
    int Save();

}
