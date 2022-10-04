using FluentValidation;

namespace Libreria.Application.Features.Editoriales.Commands.Update
{


    public class UpdateEditorialCommandValidator : AbstractValidator<UpdateEditorialCommand>
    {
        public UpdateEditorialCommandValidator()
        {

            // Validacion para el nombre
            // No puede ser vacio, nulo y no puede exceder de 50 caracteres
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede ser en blanco")
                .NotNull().WithMessage("{Nombre} no puede ser nulo")
                .MaximumLength(70).WithMessage("{Nombre} no exceder 70 caracteres");


        }
    }
}


