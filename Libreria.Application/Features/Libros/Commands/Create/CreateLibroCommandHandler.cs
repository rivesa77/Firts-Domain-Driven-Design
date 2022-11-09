using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Libros.Commands.Create
{
    public class CreateLibroCommandHandler : IRequestHandler<CreateLibroCommand, int>
    {
        private readonly ILogger<CreateLibroCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLibroCommandHandler(ILogger<CreateLibroCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateLibroCommand request, CancellationToken cancellationToken)
        {
            var libroEntity = _mapper.Map<Libro>(request);

            _unitOfWork.Repository<Libro>().AddEntity(libroEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("No se inserto el record del libro");
                throw new Exception("No se pudo insertar el record del libro");
            }

            // Por ahora unica forma de poder añadir la relacion libro-> autor dentro del BD
            // No creo que sea la forma mas elegante de hacerlo, pero por ahora funciona correctamente

            var libroAutor = new LibroAutor
            {
                AutorId = request.AutorId,
                LibroId = libroEntity.Id
            };

            _unitOfWork.Repository<LibroAutor>().AddEntity(libroAutor);

            var result2 = await _unitOfWork.Complete();

            if (result2 <= 0)
            {
                _logger.LogError("No se inserto el record de libroAutor");
                throw new Exception("No se pudo insertar el record de libroAutor");
            }

            return libroEntity.Id;
        }
    }
}