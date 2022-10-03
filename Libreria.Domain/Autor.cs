using Libreria.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Libreria.Domain
{

    public class Autor : BaseDomainModel
    {

        public Autor()
        {
            Libros = new List<Libro>();
        }

        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string Nacionalidad { get; set; }

        [JsonIgnore]
        public virtual ICollection<Libro> Libros{ get; set; }




    }

}
