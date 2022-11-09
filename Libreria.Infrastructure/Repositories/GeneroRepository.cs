using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using Libreria.Infrastructure.Persistence;

namespace Libreria.Infrastructure.Repositories
{
    public class GeneroRepository : RepositoryBase<Genero>, IGeneroRepository
    {
        public GeneroRepository(LibreriaDbContext context) : base(context)
        {
        }
    }
}