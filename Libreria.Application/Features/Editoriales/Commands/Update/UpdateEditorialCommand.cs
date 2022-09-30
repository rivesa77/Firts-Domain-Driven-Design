using MediatR;

namespace Libreria.Application.Features.Editoriales.Commands.Update
{
    public class UpdateEditorialCommand : IRequest
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
