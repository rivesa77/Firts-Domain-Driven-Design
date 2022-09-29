using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Exceptions;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Autores.Commands.Update
{

    public class UpdateAutorCommandHandler : IRequestHandler<UpdateAutorCommand>
    {
        private readonly IAutorRepository autorRepository;
        private readonly IMapper mapper;
        // Obtenemos el log de la inserccion
        private readonly ILogger<UpdateAutorCommandHandler> logger;

        public UpdateAutorCommandHandler(IAutorRepository autorRepository, IMapper mapper, ILogger<UpdateAutorCommandHandler> logger)
        {
            this.autorRepository = autorRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
        {
            // Comprobamos en la BD si existe el objeto 
            var autorToUpdate = await autorRepository.GetByIdAsync(request.Id);
            if (autorToUpdate is null)
            {
                logger.LogError($"No se encontro el autor Id {request.Id}");
                throw new NotFoundException(nameof(Autor), request.Id);
            }

            // request dato origen actualizar
            // request dato destino actualizar
            // tipo de dato origen
            // tipo de dato destino
            mapper.Map(request, autorToUpdate, typeof(UpdateAutorCommand), typeof(Autor));

            // llamamos a la actualizacion base, con el parametro del objeto a actualizar
            await autorRepository.UpdateAsync(autorToUpdate);
            logger.LogInformation($"Se ha actualizado correctamente el autor {request.Id}");
            return Unit.Value;
        }
    }

}
