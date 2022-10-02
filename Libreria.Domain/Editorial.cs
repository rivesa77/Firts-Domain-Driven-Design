using Libreria.Domain.Common;
using System.Text.Json.Serialization;

namespace Libreria.Domain
{
    public class Editorial : BaseDomainModel
    {

        public Editorial()
        {
            Libros = new List<Libro>();
        }

        public string Nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Libro> Libros { get; set; }

    }

}
