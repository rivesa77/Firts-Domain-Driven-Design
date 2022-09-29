using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        //public NotFoundException(string message, object key) : base($"Entity \"{message}\" ({key}) no fue encontrado")
        public NotFoundException(string message, object key) : base($"Entidad ({key}) no existe en la BD"+Environment.NewLine)
        {

        }
    }
}
