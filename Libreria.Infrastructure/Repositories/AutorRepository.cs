using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using Libreria.Infrastructure.Persistence;

namespace Libreria.Infrastructure.Repositories
{
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
        public AutorRepository(LibreriaDbContext context) : base(context)
        {

        }


    }

}
