using FluentValidation;
using MediatR;

namespace Libreria.Application.Behaviours
{
    // Para esta clase hay que definir el tipo de dato para TRequest es del tipo IRequest casteando un TResponse añadiendo
    // where TRequest : IRequest<TResponse>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                // Capturamos las validaciones escritas en la aplicacion
                // Estas comprobaciones se realiza en el pipeline
                var validationResult = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count > 0)
                {
                    throw new ValidationException(failures);
                }
            }

            // Continua el flujo si no hay errores de validacion
            return await next();
        }
    }
}