using Libreria.Domain.Common;

namespace Libreria.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        ILibroRepository LibroRepository { get; }
        IAutorRepository AutorRepository { get; }
        IGeneroRepository GeneroRepository { get; }
        IEditorialRepository EditorialRepository { get; }

        ILibroAutorRepository LibroAutorRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
