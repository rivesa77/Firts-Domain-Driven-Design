using Libreria.Domain.Common;

namespace Libreria.Domain
{
    public class Precio : BaseDomainModel
    {
        public Precio()
        {
        }

        public DateTime Fecha { get; set; }

        public decimal Importe { get; set; }

        public int LibroId { get; set; }

        public virtual Libro Libro { get; set; }
    }
}