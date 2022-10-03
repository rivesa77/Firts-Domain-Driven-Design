using MediatR;

namespace Libreria.Application.Features.Generos.Commands.Update
{

    public class UpdateGeneroCommand : IRequest
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

    }

}
