using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Libros.Commands.Update
{
    public class UpdateLibroCommand : IRequest
    {

        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Asin { get; set; } = string.Empty;
        public int Paginas { get; set; }
        public int EditorialId { get; set; }

    }
    
}
