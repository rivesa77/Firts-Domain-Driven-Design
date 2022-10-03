using Libreria.Domain;

namespace Libreria.Application.Features.Autores.Queries.ViewModels
{
    public class AutorVM_Complete
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string Nacionalidad { get; set; }


        public virtual ICollection<Libro> Libros { get; set; }

    }
}
