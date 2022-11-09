using Libreria.Application.Features.Libros.Queries.ViewModels;

namespace Libreria.Application.Features.Autores.Queries.ViewModels
{
    /// <summary>
    /// Pruebas de como mostrar los datos que devolvemos al controller que lo llama
    /// No tiene sentido hacer varios modelo pero solo quiero probar que se puede hacer
    /// </summary>
    public class AutorVM_Complete
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string Nacionalidad { get; set; }

        public virtual ICollection<LibroVM_Simple> Libros { get; set; }
    }
}