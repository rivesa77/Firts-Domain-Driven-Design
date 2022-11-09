using Libreria.Domain;

namespace Libreria.Application.Contracts.Persistence
{
    public interface ILibroRepository : IAsyncRepository<Libro>
    {
        Task<IEnumerable<Libro>> GetLibrosByTitle(string titulo);

        Task<Libro> GetLibroById(int Id);

        Task<IEnumerable<Libro>> GetLibrosList();
    }
}