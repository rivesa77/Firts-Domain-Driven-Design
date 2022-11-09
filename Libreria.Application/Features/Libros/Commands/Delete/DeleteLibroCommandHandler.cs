using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Exceptions;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Libros.Commands.Delete
{
    public class DeleteLibroCommandHandler : IRequestHandler<DeleteLibroCommand>
    {
        private readonly ILibroRepository libroRepository;
        private readonly IMapper mapper;

        // Obtenemos el log del borrado
        private readonly ILogger<DeleteLibroCommandHandler> logger;

        public DeleteLibroCommandHandler(ILibroRepository libroRepository, IMapper mapper, ILogger<DeleteLibroCommandHandler> logger)
        {
            this.libroRepository = libroRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(DeleteLibroCommand request, CancellationToken cancellationToken)
        {
            // Comprobamos en la BD si existe el objeto
            var libroToDelte = await libroRepository.GetByIdAsync(request.Id);
            if (libroToDelte is null)
            {
                logger.LogError($"No se encontro el libro Id {request.Id}");
                throw new NotFoundException(nameof(Libro), request.Id);
            }

            // llamamos a la actualizacion base, con el parametro del objeto a actualizar
            await libroRepository.DeleteAsync(libroToDelte);
            logger.LogInformation($"Se ha borrado correctamente el libro {request.Id}");
            return Unit.Value;
        }
    }
}