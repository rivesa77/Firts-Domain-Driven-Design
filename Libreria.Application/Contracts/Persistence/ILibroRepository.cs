using Libreria.Domain;

namespace Libreria.Application.Contracts.Persistence
{
    public interface ILibroRepository : IAsyncRepository<Libro>
    {
        Task<IEnumerable<Libro>> GetLibrosAutorByTitle(string titulo);

        Task<IEnumerable<Libro>> GetLibrosListQuery();
    }
}
