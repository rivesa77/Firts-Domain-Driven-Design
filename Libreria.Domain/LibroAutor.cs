using Libreria.Domain.Common;

namespace Libreria.Domain
{
    public class LibroAutor : BaseDomainModel
    {
        public int LibroId { get; set; }
        public int AutorId { get; set; }

        public Libro? Libro { get; set; }

        public Autor? Autor { get; set; }
    }
}