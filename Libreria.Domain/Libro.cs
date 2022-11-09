using Libreria.Domain.Common;

namespace Libreria.Domain
{
    public class Libro : BaseDomainModel
    {
        public Libro()
        {
            Precios = new List<Precio>();
            Generos = new List<Genero>();
            Autores = new List<Autor>();
            LibroGenero = new List<LibroGenero>();
            LibroAutor = new List<LibroAutor>();
        }

        public string Titulo { get; set; } = string.Empty;
        public string Asin { get; set; } = string.Empty;
        public int Paginas { get; set; }

        public int EditorialId { get; set; }

        public Editorial Editorial { get; set; }

        public virtual ICollection<Precio> Precios { get; set; }
        public virtual ICollection<Genero> Generos { get; set; }
        public virtual ICollection<LibroGenero>? LibroGenero { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }
        public virtual ICollection<LibroAutor>? LibroAutor { get; set; }
    }
}