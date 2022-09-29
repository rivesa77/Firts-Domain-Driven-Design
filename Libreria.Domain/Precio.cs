using Libreria.Domain.Common;

namespace Libreria.Domain
{
    public class Precio : BaseDomainModel
    {

        public Precio()
        {
            Libros = new List<Libro>();
        }

        public DateTime Fecha { get; set; }

        public decimal Importe { get; set; }

        public int LibroId { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }

    }
}
