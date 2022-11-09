using Libreria.Application.Features.Libros.Queries.ViewModels;
using MediatR;

namespace Libreria.Application.Features.Libros.Queries.GetLibroById
{
    public class GetLibroById : IRequest<LibroVM_Complete>
    {
        // Parametro de entrada
        public int Id { get; set; }

        public GetLibroById(int? Id)
        {
            // en caso de que no exista envia una excepcion
            this.Id = Id ?? throw new ArgumentException(Id.ToString());
        }
    }
}