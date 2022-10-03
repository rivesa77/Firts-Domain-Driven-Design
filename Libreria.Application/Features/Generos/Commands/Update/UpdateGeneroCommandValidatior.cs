using FluentValidation;

namespace Libreria.Application.Features.Generos.Commands.Update
{

    public class UpdateGeneroCommandValidatior : AbstractValidator<UpdateGeneroCommand>
    {
        public UpdateGeneroCommandValidatior()
        {

            // Validacion para el nombre
            // No puede ser vacio, nulo y no puede exceder de 50 caracteres
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede ser en blanco")
                .NotNull().WithMessage("{Nombre} no puede ser nulo")
                .MaximumLength(70).WithMessage("{Nombre} no exceder 50 caracteres");


        }
    }
}
