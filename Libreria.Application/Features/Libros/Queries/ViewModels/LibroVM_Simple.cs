using Libreria.Application.Features.Autores.Queries.ViewModels;
using Libreria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Libros.Queries.ViewModels
{
    /// <summary>
    /// Pruebas de como mostrar los datos que devolvemos al controller que lo llama
    /// No tiene sentido hacer varios modelo pero solo quiero probar que se puede hacer
    /// </summary>
    public class LibroVM_Simple
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Asin { get; set; }
        public int Paginas { get; set; }

        public int EditorialId { get; set; }

        

    }

}
