using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using Libreria.Infrastructure.Persistence;

namespace Libreria.Infrastructure.Repositories
{
    public class LibroGeneroRepository : RepositoryBase<LibroGenero>, ILibroGeneroRepository
    {
        public LibroGeneroRepository(LibreriaDbContext context) : base(context)
        {
        }
    }
}