using FluentValidation.Results;

namespace Libreria.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException() : base("Se han encontrado los siguientes errores")
        {
            Errors = new Dictionary<string, string[]>();
        }

        //Obtiene un listado con un o mas error de validacion ocurrido
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(p => p.PropertyName, p => p.ErrorMessage)
                .ToDictionary(fallo => fallo.Key, fallo => fallo.ToArray());
        }
    }
}