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
        }

        public string Titulo { get; set; }
        public string Asin { get; set; }
        public int Paginas { get; set; }

        public Editorial Editorial { get; set; }

        public virtual ICollection<Precio> Precios { get; set; }
        public virtual ICollection<Genero> Generos { get; set; }
        public virtual ICollection<Autor> Autores { get; set; }


    }

}
