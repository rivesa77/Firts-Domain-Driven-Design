using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Generos.Commands.Update
{

    public class UpdateGeneroCommand : IRequest
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

    }

}
