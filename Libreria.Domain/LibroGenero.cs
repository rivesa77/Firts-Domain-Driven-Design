using Libreria.Domain.Common;

namespace Libreria.Domain
{
    public class LibroGenero : BaseDomainModel
    {
        public int LibroId { get; set; }
        public int GeneroId { get; set; }

        public Libro? Libro { get; set; }

        public Genero? Genero { get; set; }
    }
}