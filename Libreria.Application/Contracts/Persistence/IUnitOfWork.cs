using Libreria.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        ILibroRepository LibroRepository { get; }
        IAutorRepository AutorRepository { get; }
        IGeneroRepository GeneroRepository { get; }
        IEditorialRepository EditorialRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
