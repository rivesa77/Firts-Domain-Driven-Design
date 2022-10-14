using Libreria.Application.Features.Libros.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Editoriales.Queries.ViewModels
{

    public class EditorialVM_Complete
    {

        public string Nombre { get; set; }
        public virtual ICollection<LibroVM_Simple> Libros { get; set; }

    }

}
