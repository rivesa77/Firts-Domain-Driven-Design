using FluentValidation;

namespace Libreria.Application.Features.Libros.Commands.Create
{
    public class CreateLibroCommandValidator : AbstractValidator<CreateLibroCommand>
    {
        public CreateLibroCommandValidator()
        {
            RuleFor(p => p.Titulo)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");

            RuleFor(p => p.Asin)
                .NotNull().WithMessage("{asin} no puede ser nulo");

            RuleFor(p => p.Paginas)                                
                .GreaterThan(0).WithMessage("{paginas} no puede ser 0");


        }
    }
}
