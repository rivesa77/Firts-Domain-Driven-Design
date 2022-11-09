using MediatR;

namespace Libreria.Application.Features.Generos.Commands.Delete
{
    public class DeleteGeneroCommand : IRequest
    {
        public int Id { get; set; }
    }
}