using Libreria.Domain.Common;

namespace Libreria.Domain
{
    public class Editorial : BaseDomainModel
    {
        public Editorial()
        {
            Libros = new List<Libro>();
        }

        public string Nombre { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}