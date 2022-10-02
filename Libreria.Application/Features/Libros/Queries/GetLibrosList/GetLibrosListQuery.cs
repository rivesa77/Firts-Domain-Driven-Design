using MediatR;

namespace Libreria.Application.Features.Libros.Queries.GetLibrosList
{
    public class GetLibrosListQuery : IRequest<List<LibroVM>>
    {
    }

}
