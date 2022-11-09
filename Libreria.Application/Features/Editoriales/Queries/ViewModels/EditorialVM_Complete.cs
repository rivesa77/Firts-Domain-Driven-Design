using Libreria.Application.Features.Libros.Queries.ViewModels;

namespace Libreria.Application.Features.Editoriales.Queries.ViewModels
{
    public class EditorialVM_Complete
    {
        public string Nombre { get; set; }
        public virtual ICollection<LibroVM_Simple> Libros { get; set; }
    }
}