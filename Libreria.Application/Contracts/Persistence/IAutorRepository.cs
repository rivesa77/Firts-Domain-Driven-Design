using Libreria.Domain;

namespace Libreria.Application.Contracts.Persistence
{
    public interface IAutorRepository : IAsyncRepository<Autor>
    {

        Task<IEnumerable<Autor>> GetAutorByName(string nombre);

    }
}
