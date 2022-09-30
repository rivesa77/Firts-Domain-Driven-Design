using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Exceptions;
using Libreria.Application.Features.Libros.Commands.Update;
using Libreria.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Libros.Commands.Update
{
    public class UpdateLibroCommandHandler : IRequestHandler<UpdateLibroCommand>
    {
        private readonly ILibroRepository libroRepository;
        private readonly IMapper mapper;
        // Obtenemos el log de la inserccion
        private readonly ILogger<UpdateLibroCommandHandler> logger;

        public UpdateLibroCommandHandler(ILibroRepository libroRepository, IMapper mapper, ILogger<UpdateLibroCommandHandler> logger)
        {
            this.libroRepository = libroRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UpdateLibroCommand request, CancellationToken cancellationToken)
        {
            // Comprobamos en la BD si existe el objeto 
            var libroToUpdate = await libroRepository.GetByIdAsync(request.Id);
            if (libroToUpdate is null)
            {
                logger.LogError($"No se encontro el libro Id {request.Id}");
                throw new NotFoundException(nameof(Libro), request.Id);
            }

            // request dato origen actualizar
            // request dato destino actualizar
            // tipo de dato origen
            // tipo de dato destino
            mapper.Map(request, libroToUpdate, typeof(UpdateLibroCommand), typeof(Libro));

            // llamamos a la actualizacion base, con el parametro del objeto a actualizar
            await libroRepository.UpdateAsync(libroToUpdate);
            logger.LogInformation($"Se ha actualizado correctamente el libro {request.Id}");
            return Unit.Value;
        }
    }
}
