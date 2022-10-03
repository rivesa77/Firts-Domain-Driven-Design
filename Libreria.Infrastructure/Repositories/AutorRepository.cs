using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using Libreria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Libreria.Infrastructure.Repositories
{
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
        public AutorRepository(LibreriaDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Autor>> GetAutorByName(string nombre)
        {
            return await context.Autor!.Where(l => l.Nombre.ToLower().Contains(nombre.ToLower())).Include(x => x.Libros).ThenInclude(x=>x.Generos).ToListAsync();
        }

        
    }

}
