using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Exceptions;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Generos.Commands.Update
{
    public class UpdateGeneroCommandHandler : IRequestHandler<UpdateGeneroCommand>
    {
        private readonly IGeneroRepository generoRepository;
        private readonly IMapper mapper;

        // Obtenemos el log de la inserccion
        private readonly ILogger<UpdateGeneroCommandHandler> logger;

        public UpdateGeneroCommandHandler(IGeneroRepository generoRepository, IMapper mapper, ILogger<UpdateGeneroCommandHandler> logger)
        {
            this.generoRepository = generoRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UpdateGeneroCommand request, CancellationToken cancellationToken)
        {
            // Comprobamos en la BD si existe el objeto
            var generoToUpdate = await generoRepository.GetByIdAsync(request.Id);
            if (generoToUpdate is null)
            {
                logger.LogError($"No se encontro el genero Id {request.Id}");
                throw new NotFoundException(nameof(Genero), request.Id);
            }

            // request dato origen actualizar
            // request dato destino actualizar
            // tipo de dato origen
            // tipo de dato destino
            mapper.Map(request, generoToUpdate, typeof(UpdateGeneroCommand), typeof(Genero));

            // llamamos a la actualizacion base, con el parametro del objeto a actualizar
            await generoRepository.UpdateAsync(generoToUpdate);
            logger.LogInformation($"Se ha actualizado correctamente el genero {request.Id}");
            return Unit.Value;
        }
    }
}