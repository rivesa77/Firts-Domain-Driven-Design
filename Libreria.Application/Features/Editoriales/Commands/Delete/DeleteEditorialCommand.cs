using MediatR;

namespace Libreria.Application.Features.Editoriales.Commands.Delete
{
    public class DeleteEditorialCommand : IRequest
    {
        public int Id { get; set; }
    }
}