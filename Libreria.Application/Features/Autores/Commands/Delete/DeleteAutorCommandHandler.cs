using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Exceptions;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Autores.Commands.Delete
{
    public class DeleteAutorCommandHandler : IRequestHandler<DeleteAutorCommand>
    {
        private readonly IAutorRepository autorRepository;
        private readonly IMapper mapper;

        // Obtenemos el log del borrado
        private readonly ILogger<DeleteAutorCommandHandler> logger;

        public DeleteAutorCommandHandler(IAutorRepository autorRepository, IMapper mapper, ILogger<DeleteAutorCommandHandler> logger)
        {
            this.autorRepository = autorRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
        {
            // Comprobamos en la BD si existe el objeto
            var autorToDelte = await autorRepository.GetByIdAsync(request.Id);
            if (autorToDelte is null)
            {
                logger.LogError($"No se encontro el autor Id {request.Id}");
                throw new NotFoundException(nameof(Autor), request.Id);
            }

            // llamamos a la actualizacion base, con el parametro del objeto a actualizar
            await autorRepository.DeleteAsync(autorToDelte);
            logger.LogInformation($"Se ha borrado correctamente el autor {request.Id}");
            return Unit.Value;
        }
    }
}