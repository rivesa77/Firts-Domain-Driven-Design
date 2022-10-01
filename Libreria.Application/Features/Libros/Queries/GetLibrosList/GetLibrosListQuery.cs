using MediatR;

namespace Libreria.Application.Features.Libros.Queries.GetLibrosList
{


    public class GetLibrosListQuery : IRequest<List<LibroVM>>
    {
        // Parametro de entrada
        public string titulo { get; set; } = String.Empty;

        public GetLibrosListQuery(string? titulo)
        {
            // en caso de que no exista envia una excepcion
            titulo = titulo;
        }
    }

}
