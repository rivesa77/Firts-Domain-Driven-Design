using Libreria.Domain.Common;

namespace Libreria.Domain
{

    public class Genero : BaseDomainModel
    {

        public Genero()
        {
            Libros = new List<Libro>();
        }

        public string Nombre { get; set; } = string.Empty;

        public virtual ICollection<Libro> Libros { get; set; }

    }

}
