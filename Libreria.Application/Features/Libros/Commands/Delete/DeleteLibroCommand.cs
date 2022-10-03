using MediatR;

namespace Libreria.Application.Features.Libros.Commands.Delete
{
    public class DeleteLibroCommand : IRequest
    {
        public int Id { get; set; }
    }
}
