using Libreria.Domain.Common;
using System.Text.Json.Serialization;

namespace Libreria.Domain
{

    public class Genero : BaseDomainModel
    {

        public Genero()
        {
            Libros = new List<Libro>();
        }

        public string Nombre { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Libro> Libros { get; set; }

    }

}
