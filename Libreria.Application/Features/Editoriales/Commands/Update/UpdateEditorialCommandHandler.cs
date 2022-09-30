using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Exceptions;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Editoriales.Commands.Update
{


    public class UpdateEditorialCommandHandler : IRequestHandler<UpdateEditorialCommand>
    {
        private readonly IEditorialRepository editorialRepository;
        private readonly IMapper mapper;
        // Obtenemos el log de la inserccion
        private readonly ILogger<UpdateEditorialCommandHandler> logger;

        public UpdateEditorialCommandHandler(IEditorialRepository editorialRepository, IMapper mapper, ILogger<UpdateEditorialCommandHandler> logger)
        {
            this.editorialRepository = editorialRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UpdateEditorialCommand request, CancellationToken cancellationToken)
        {
            // Comprobamos en la BD si existe el objeto 
            var editorialToUpdate = await editorialRepository.GetByIdAsync(request.Id);
            if (editorialToUpdate is null)
            {
                logger.LogError($"No se encontro el editorial Id {request.Id}");
                throw new NotFoundException(nameof(Editorial), request.Id);
            }

            // request dato origen actualizar
            // request dato destino actualizar
            // tipo de dato origen
            // tipo de dato destino
            mapper.Map(request, editorialToUpdate, typeof(UpdateEditorialCommand), typeof(Editorial));

            // llamamos a la actualizacion base, con el parametro del objeto a actualizar
            await editorialRepository.UpdateAsync(editorialToUpdate);
            logger.LogInformation($"Se ha actualizado correctamente el editorial {request.Id}");
            return Unit.Value;
        }
    }

}
