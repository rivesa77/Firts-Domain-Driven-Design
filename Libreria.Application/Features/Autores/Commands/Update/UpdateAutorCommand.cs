using MediatR;

namespace Libreria.Application.Features.Autores.Commands.Update
{
    public class UpdateAutorCommand : IRequest
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string Nacionalidad { get; set; }


    }

}
