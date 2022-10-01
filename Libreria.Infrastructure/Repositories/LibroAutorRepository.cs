using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using Libreria.Infrastructure.Persistence;

namespace Libreria.Infrastructure.Repositories
{

    public class LibroAutorRepository : RepositoryBase<LibroAutor>, ILibroAutorRepository
    {
        public LibroAutorRepository(LibreriaDbContext context) : base(context)
        {

        }
    }

}
