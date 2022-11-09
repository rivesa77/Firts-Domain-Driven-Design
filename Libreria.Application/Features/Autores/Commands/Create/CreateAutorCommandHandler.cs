using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libreria.Application.Features.Autores.Commands.Create
{
    public class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, int>
    {
        private readonly IAutorRepository autorRepository;
        private readonly IMapper mapper;

        // Obtenemos el log de la inserccion
        private readonly ILogger<CreateAutorCommandHandler> logger;

        public CreateAutorCommandHandler(IAutorRepository autorRepository, IMapper mapper, ILogger<CreateAutorCommandHandler> logger)
        {
            this.autorRepository = autorRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
        {
            var autorEntity = mapper.Map<Autor>(request);
            var newAutor = await autorRepository.AddAsync(autorEntity);
            logger.LogInformation($"Autor {newAutor.Id} fue creado existosamente");

            return newAutor.Id;
        }
    }
}