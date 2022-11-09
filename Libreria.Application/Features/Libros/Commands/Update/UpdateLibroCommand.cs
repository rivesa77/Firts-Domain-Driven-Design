using MediatR;

namespace Libreria.Application.Features.Libros.Commands.Update
{
    public class UpdateLibroCommand : IRequest
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Asin { get; set; } = string.Empty;
        public int Paginas { get; set; }
        public int EditorialId { get; set; }
    }
}