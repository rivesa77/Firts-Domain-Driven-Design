using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Exceptions;

using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Generos.Commands.Delete
{


    public class DeleteGeneroCommandHandler : IRequestHandler<DeleteGeneroCommand>
    {

        private readonly IGeneroRepository generoRepository;
        private readonly IMapper mapper;
        // Obtenemos el log del borrado
        private readonly ILogger<DeleteGeneroCommandHandler> logger;

        public DeleteGeneroCommandHandler(IGeneroRepository generoRepository, IMapper mapper, ILogger<DeleteGeneroCommandHandler> logger)
        {
            this.generoRepository = generoRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(DeleteGeneroCommand request, CancellationToken cancellationToken)
        {
            // Comprobamos en la BD si existe el objeto 
            var generoToDelte = await generoRepository.GetByIdAsync(request.Id);
            if (generoToDelte is null)
            {
                logger.LogError($"No se encontro el genero Id {request.Id}");
                throw new NotFoundException(nameof(Genero), request.Id);
            }


            // llamamos a la actualizacion base, con el parametro del objeto a actualizar
            await generoRepository.DeleteAsync(generoToDelte);
            logger.LogInformation($"Se ha borrado correctamente el genero {request.Id}");
            return Unit.Value;
        }
    }

}
