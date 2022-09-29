using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Editoriales.Commands.Create
{


    public class CreateEditorialCommandHandler : IRequestHandler<CreateEditorialCommand, int>
    {
        private readonly ILogger<CreateEditorialCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEditorialCommandHandler(ILogger<CreateEditorialCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateEditorialCommand request, CancellationToken cancellationToken)
        {
            var editorialEntity = _mapper.Map<Autor>(request);

            _unitOfWork.Repository<Autor>().AddEntity(editorialEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("No se inserto el record de la editorial");
                throw new Exception("No se pudo insertar el record de la editorial");
            }

            return editorialEntity.Id;
        }
    }

    
}
