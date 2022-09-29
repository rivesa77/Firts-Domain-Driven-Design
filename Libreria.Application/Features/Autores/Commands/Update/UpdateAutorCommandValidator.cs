using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Autores.Commands.Update
{

    public class UpdateAutorCommandValidator : AbstractValidator<UpdateAutorCommand>
    {
        public UpdateAutorCommandValidator()
        {

            // Validacion para el nombre
            // No puede ser vacio, nulo y no puede exceder de 50 caracteres
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede ser en blanco")
                .NotNull().WithMessage("{Nombre} no puede ser nulo")
                .MaximumLength(70).WithMessage("{Nombre} no exceder 50 caracteres");


            // Validacion para el nombre
            // No puede ser vacio, nulo y no puede exceder de 50 caracteres
            RuleFor(p => p.Nacionalidad)
                .NotEmpty().WithMessage("{Url} no puede ser en blanco")
                .NotNull().WithMessage("{Url} no puede ser nulo")
                .MaximumLength(25).WithMessage("{Url} no exceder 50 caracteres");

        }
    }

}
