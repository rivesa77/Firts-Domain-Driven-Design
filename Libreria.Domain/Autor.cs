using Libreria.Domain.Common;
using System.Text.Json.Serialization;

namespace Libreria.Domain
{

    public class Autor : BaseDomainModel
    {

        public Autor()
        {
            Libros = new List<Libro>();            
            LibroAutor = new List<LibroAutor>();
        }

        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string Nacionalidad { get; set; }

        
        public virtual ICollection<Libro> Libros{ get; set; }
        public virtual ICollection<LibroAutor>? LibroAutor { get; set; }




    }

}
