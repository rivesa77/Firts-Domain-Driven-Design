using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using Libreria.Infrastructure.Persistence;

namespace Libreria.Infrastructure.Repositories
{
    public class EditorialRepository : RepositoryBase<Editorial>, IEditorialRepository
    {
        public EditorialRepository(LibreriaDbContext context) : base(context)
        {
        }
    }
}