using Libreria.Application.Features.Libros.Queries.ViewModels;

namespace Libreria.Application.Features.Generos.Queries.ViewModel
{
    public class GeneroVM_Complete
    {
        public string Nombre { get; set; }
        public virtual ICollection<LibroVM_Simple> Libros { get; set; }
    }
}