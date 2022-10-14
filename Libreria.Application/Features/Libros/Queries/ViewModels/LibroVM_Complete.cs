using Libreria.Application.Features.Autores.Queries.ViewModels;
using Libreria.Application.Features.Editoriales.Queries.ViewModels;
using Libreria.Application.Features.Generos.Queries.ViewModel;
using Libreria.Domain;

namespace Libreria.Application.Features.Libros.Queries.ViewModels
{
    /// <summary>
    /// Pruebas de como mostrar los datos que devolvemos al controller que lo llama
    /// No tiene sentido hacer varios modelo pero solo quiero probar que se puede hacer
    /// </summary>
    public class LibroVM_Complete
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Asin { get; set; }
        public int Paginas { get; set; }

        public int EditorialId { get; set; }

        public virtual ICollection<AutorVM_Simple> Autores { get; set; }

        public virtual ICollection<GeneroVM_Simple> Generos { get; set; }

        public virtual EditorialVM_Simple Editorial { get; set; }



    }
}
