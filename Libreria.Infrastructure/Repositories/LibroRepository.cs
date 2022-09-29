using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using Libreria.Infrastructure.Persistence;

namespace Libreria.Infrastructure.Repositories
{

    public class LibroRepository : RepositoryBase<Libro>, ILibroRepository
    {
        public LibroRepository(LibreriaDbContext context) : base(context)
        {

        }

        public Task<Libro> GetLibroByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
