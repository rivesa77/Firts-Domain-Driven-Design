using Libreria.Domain;

namespace Libreria.Application.Features.Libros.Queries
{
    public class LibroVM
    {
        public string Titulo { get; set; } 
        public string Asin { get; set; } 
        public int Paginas { get; set; }

        public int EditorialId { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }

    }
}
