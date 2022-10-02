using Libreria.Domain;

namespace Libreria.Application.Features.Libros.Queries
{
    public class LibroVM
    {
        public int Id { get; set; }
        public string Titulo { get; set; } 
        public string Asin { get; set; } 
        public int Paginas { get; set; }

        public int EditorialId { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }

        public virtual ICollection<Genero> Generos { get; set; }

        public virtual Editorial Editorial { get; set; }

        
    }
}
