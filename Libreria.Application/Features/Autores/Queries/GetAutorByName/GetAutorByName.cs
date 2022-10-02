using Libreria.Application.Features.Autores.Queries.ViewModels;
using MediatR;

namespace Libreria.Application.Features.Autores.Queries.GetAutorByName
{

    public class GetAutorByName : IRequest<List<AutorVM_Complete>>
    {
        // Parametro de entrada
        public string Nombre { get; set; } = String.Empty;

        public GetAutorByName(string? nombre)
        {
            // en caso de que no exista envia una excepcion
            this.Nombre = nombre ?? throw new ArgumentException((nombre));
        }
    }

}
