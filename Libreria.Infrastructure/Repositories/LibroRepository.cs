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

        /// <summary>
        /// Retorna listado de todos los libros con todas sus entidades relacionadas
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Libro>> GetLibrosList()
        {
            //return await context.Libro!.Include(x => x.Autores).AsSplitQuery().Include(x => x.Editorial).AsSplitQuery().Include(x => x.Generos).AsSplitQuery().ToListAsync();
            return await context.Libro!.Include(x => x.Autores).AsSplitQuery().Include(x => x.Editorial).AsSplitQuery().Include(x => x.Generos).AsSplitQuery().ToListAsync();
        }


        /// <summary>
        /// Obtiene Libro por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Libro> GetLibroById(int Id)
        {
            //return await context.Libro!.FindAsync(Id);
            return await context.Libro!.Where(x=>x.Id == Id).Include(x => x.Autores).AsSplitQuery().Include(x => x.Editorial).AsSplitQuery().Include(x => x.Generos).AsSplitQuery().FirstOrDefaultAsync();
        }
    }
}
