using FluentValidation;

namespace Libreria.Application.Features.Generos.Commands.Create
{
    public class CreateGeneroCommandValidator : AbstractValidator<CreateGeneroCommand>
    {
        public CreateGeneroCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");


        }
    }
}
