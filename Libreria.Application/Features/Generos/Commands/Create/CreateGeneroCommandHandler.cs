using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Generos.Commands.Create
{


    public class CreateGeneroCommandHandler : IRequestHandler<CreateGeneroCommand, int>
    {
        private readonly ILogger<CreateGeneroCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGeneroCommandHandler(ILogger<CreateGeneroCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateGeneroCommand request, CancellationToken cancellationToken)
        {
            var generoEntity = _mapper.Map<Genero>(request);

            _unitOfWork.Repository<Genero>().AddEntity(generoEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("No se inserto el record del genero");
                throw new Exception("No se pudo insertar el record del genero");
            }

            return generoEntity.Id;
        }
    }

    
}
