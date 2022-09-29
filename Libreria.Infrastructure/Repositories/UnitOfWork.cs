using Libreria.Application.Contracts.Persistence;
using Libreria.Domain.Common;
using Libreria.Infrastructure.Persistence;
using System.Collections;

namespace Libreria.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable repositories;
        private readonly LibreriaDbContext context;

        //Trabajamos con el unitOfWork pero con entidades personalizadas
        private ILibroRepository _libroRepository;
        private IAutorRepository _autorRepository;
        private IGeneroRepository _generoRepository;
        private IEditorialRepository _editorialRepository;

        // Vamos a inyectarlo no via constructor, si no via propiedades de la clase unitOfWork
        // Estas 2 variable son la implementacion definida en IUnitOfWork
        public ILibroRepository LibroRepository => _libroRepository ??= new LibroRepository(context);
        public IAutorRepository AutorRepository => _autorRepository ??= new AutorRepository(context);
        public IGeneroRepository GeneroRepository => _generoRepository ??= new GeneroRepository(context);
        public IEditorialRepository EditorialRepository => _editorialRepository ??= new EditorialRepository(context);


        public UnitOfWork(LibreriaDbContext context)
        {
            this.context = context;
        }

        public LibreriaDbContext LibreriaDbContext => context;// Propiedad para devolver el context con un get

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        //Instancia del repositorio
        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (repositories == null)
                repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                // No hay que llamar a la inferfaz de IAsyncRepository, si no a la implementacion de la interfaz
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);
                repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)repositories[type];
        }
    }
}
