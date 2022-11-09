using FluentValidation;

namespace Libreria.Application.Features.Autores.Commands.Create
{
    public class CreateAutorCommandValidator : AbstractValidator<CreateAutorCommand>
    {
        public CreateAutorCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");

            RuleFor(p => p.Nacionalidad)
                .NotNull().WithMessage("{Nacionalidad} no puede ser nulo");

            RuleFor(p => p.Biografia)
            .NotNull().WithMessage("{Biografia} no puede ser nulo");
        }
    }
}