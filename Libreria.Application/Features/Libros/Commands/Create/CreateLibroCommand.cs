using MediatR;

namespace Libreria.Application.Features.Libros.Commands.Create
{

    public class CreateLibroCommand : IRequest<int>
    {
        public string Titulo { get; set; } = string.Empty;
        public string Asin { get; set; } = string.Empty;
        public int Paginas { get; set; }

        public int EditorialId { get; set; }

        public int GeneroId { get; set; }

        public int AutorId { get; set; }

    }

}
