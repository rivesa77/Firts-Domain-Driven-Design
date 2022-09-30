using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Libros.Commands.Delete
{
    public class DeleteLibroCommand : IRequest
    {
        public int Id { get; set; }
    }
}
