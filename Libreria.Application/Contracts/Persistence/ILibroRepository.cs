using Libreria.Domain;

namespace Libreria.Application.Contracts.Persistence
{
    public interface ILibroRepository : IAsyncRepository<Libro>
    {
        Task<Libro> GetLibroByTitle(string title);

        Task<IEnumerable<Libro>> GetLibrosListQuery(string title);
    }
}
