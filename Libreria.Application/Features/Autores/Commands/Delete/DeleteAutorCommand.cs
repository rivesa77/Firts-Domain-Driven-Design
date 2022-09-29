using MediatR;

namespace Libreria.Application.Features.Autores.Commands.Delete
{
    public class DeleteAutorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
