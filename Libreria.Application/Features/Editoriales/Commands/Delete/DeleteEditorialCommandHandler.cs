using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Exceptions;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Editoriales.Commands.Delete
{

    public class DeleteEditorialCommandHandler : IRequestHandler<DeleteEditorialCommand>
    {

        private readonly IEditorialRepository editorialRepository;
        private readonly IMapper mapper;
        // Obtenemos el log del borrado
        private readonly ILogger<DeleteEditorialCommandHandler> logger;

        public DeleteEditorialCommandHandler(IEditorialRepository editorialRepository, IMapper mapper, ILogger<DeleteEditorialCommandHandler> logger)
        {
            this.editorialRepository = editorialRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(DeleteEditorialCommand request, CancellationToken cancellationToken)
        {
            // Comprobamos en la BD si existe el objeto 
            var editorialToDelte = await editorialRepository.GetByIdAsync(request.Id);
            if (editorialToDelte is null)
            {
                logger.LogError($"No se encontro el editorial Id {request.Id}");
                throw new NotFoundException(nameof(Editorial), request.Id);
            }


            // llamamos a la actualizacion base, con el parametro del objeto a actualizar
            await editorialRepository.DeleteAsync(editorialToDelte);
            logger.LogInformation($"Se ha borrado correctamente el editorial {request.Id}");
            return Unit.Value;
        }
    }

}
