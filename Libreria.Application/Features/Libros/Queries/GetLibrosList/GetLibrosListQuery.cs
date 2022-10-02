using Libreria.Application.Features.Libros.Queries.ViewModels;
using MediatR;

namespace Libreria.Application.Features.Libros.Queries.GetLibrosList
{
    public class GetLibrosListQuery : IRequest<List<LibroVM_Complete>>
    {
    }

}
