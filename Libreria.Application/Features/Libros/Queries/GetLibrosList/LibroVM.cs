using Libreria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Libros.Queries.GetLibrosList
{
    public class LibroVM
    {
        public string Titulo { get; set; } = string.Empty;
        public string Asin { get; set; } = string.Empty;
        public int Paginas { get; set; }

        public int EditorialId { get; set; }

        

        public virtual ICollection<Autor> Autores { get; set; }

    }
}
