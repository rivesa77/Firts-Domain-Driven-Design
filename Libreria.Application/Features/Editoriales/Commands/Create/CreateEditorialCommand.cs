using Libreria.Domain;
using MediatR;

namespace Libreria.Application.Features.Editoriales.Commands.Create
{

    public class CreateEditorialCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;

    }

}
