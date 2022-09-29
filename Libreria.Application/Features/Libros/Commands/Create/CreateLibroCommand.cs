using MediatR;

namespace Libreria.Application.Features.Libros.Commands.Create
{

    public class CreateLibroCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public string Asin { get; set; }
        public int Paginas { get; set; }

        public int EditorialId { get; set; }

    }

}
