using FluentValidation;

namespace Libreria.Application.Features.Editoriales.Commands.Create
{
    public class CreateEditorialCommandValidator : AbstractValidator<CreateEditorialCommand>
    {
        public CreateEditorialCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");
        }
    }
}