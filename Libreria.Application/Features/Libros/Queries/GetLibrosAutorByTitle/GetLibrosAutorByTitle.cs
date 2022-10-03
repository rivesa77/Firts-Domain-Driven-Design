using Libreria.Application.Features.Libros.Queries.ViewModels;
using MediatR;

namespace Libreria.Application.Features.Libros.Queries.GetLibrosAutorByTitle
{

    public class GetLibrosAutorByTitle : IRequest<List<LibroVM_Complete>>
    {
        // Parametro de entrada
        public string Titulo { get; set; } = String.Empty;


        public GetLibrosAutorByTitle(string? titulo)
        {
            // en caso de que no exista envia una excepcion
            Titulo = titulo ?? throw new ArgumentException((titulo)); 
        }
    }
}
