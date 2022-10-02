using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using Libreria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Libro>> GetLibrosListQuery()
        {

            return await context.Libro!.Include(x => x.Autores).ToListAsync();
            
        }

        //public async Task<IEnumerable<Libro>> GetLibroList()
        //{
        //    return await context.Libro!.Where(c => c.Id>0).ToListAsync();
        //    //Videos!.Where(c => c.CreateBy == username).ToListAsync();
        //}

    }
}
