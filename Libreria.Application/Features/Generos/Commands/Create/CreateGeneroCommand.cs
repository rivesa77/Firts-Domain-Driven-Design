using MediatR;

namespace Libreria.Application.Features.Generos.Commands.Create
{
    public class CreateGeneroCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;
    }
}