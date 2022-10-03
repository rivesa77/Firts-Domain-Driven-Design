using FluentValidation;

namespace Libreria.Application.Features.Libros.Commands.Update
{


    public class UpdateLibroCommandValidator : AbstractValidator<UpdateLibroCommand>
    {
        public UpdateLibroCommandValidator()
        {

            // Validacion para el nombre
            // No puede ser vacio, nulo y no puede exceder de 50 caracteres
            RuleFor(p => p.Titulo)
                .NotEmpty().WithMessage("{Titulo} no puede ser en blanco")
                .NotNull().WithMessage("{Titulo} no puede ser nulo")
                .MaximumLength(70).WithMessage("{Titulo} no exceder 50 caracteres");

            RuleFor(p => p.Asin)
                .NotEmpty().WithMessage("{Titulo} no puede ser en blanco")
                .NotNull().WithMessage("{Titulo} no puede ser nulo")
                .MaximumLength(70).WithMessage("{Titulo} no exceder 50 caracteres");


            RuleFor(p => p.Paginas)
                .Must(p=>p>0).WithMessage("{Paginas} debe ser mayor que cero")
                .Must(p => p < 1000).WithMessage("{Paginas} debe ser menr que 1000")
                ;

            RuleFor(p => p.EditorialId)
                .Must(p => p > 0).WithMessage("{IdEditorial} debe ser mayor que cero")
                .NotNull().WithMessage("{IdEditorial} no puede ser nulo")
     ;

        }
    }

}
