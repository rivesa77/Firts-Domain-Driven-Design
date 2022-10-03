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

        public async Task<IEnumerable<Libro>> GetLibrosAutorByTitle(string titulo)
        {
            return await context.Libro!.Where(l=>l.Titulo.ToLower().Contains(titulo.ToLower())).Include(x => x.Autores).ToListAsync();
        }

        public async Task<IEnumerable<Libro>> GetLibrosListQuery()
        {

            //return await context.Libro!.Include(x => x.Autores).AsSplitQuery().Include(x => x.Editorial).AsSplitQuery().Include(x => x.Generos).AsSplitQuery().ToListAsync();

            return await context.Libro!.Include(x => x.Autores).AsSplitQuery().Include(x => x.Editorial).AsSplitQuery().Include(x => x.Generos).AsSplitQuery().ToListAsync();

        }

        //public async Task<IEnumerable<Libro>> GetLibroList()
        //{
        //    return await context.Libro!.Where(c => c.Id>0).ToListAsync();
        //    //Videos!.Where(c => c.CreateBy == username).ToListAsync();
        //}

    }
}
