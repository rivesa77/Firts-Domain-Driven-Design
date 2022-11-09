using MediatR;

namespace Libreria.Application.Features.Autores.Commands.Create
{
    public class CreateAutorCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Biografia { get; set; } = string.Empty;
        public string Nacionalidad { get; set; } = string.Empty;
    }
}