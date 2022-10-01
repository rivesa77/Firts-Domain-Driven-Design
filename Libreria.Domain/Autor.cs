using Libreria.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Domain
{

    public class Autor : BaseDomainModel
    {

        public Autor()
        {
            LibrosAutor = new List<LibroAutor>();
        }

        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string Nacionalidad { get; set; }

        public virtual ICollection<LibroAutor> LibrosAutor { get; set; }

    }

}
