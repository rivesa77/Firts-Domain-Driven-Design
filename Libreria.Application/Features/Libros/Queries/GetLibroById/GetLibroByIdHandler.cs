using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Features.Libros.Queries.ViewModels;
using MediatR;

namespace Libreria.Application.Features.Libros.Queries.GetLibroById
{

    public class GetLibroByIdHandler : IRequestHandler<GetLibroById, LibroVM_Complete>
    {


        private readonly IUnitOfWork unitOfWork;
        // Mapeo de las entidades
        private readonly IMapper mapper;

        public GetLibroByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<LibroVM_Complete> Handle(GetLibroById request, CancellationToken cancellationToken)
        {
            var libro = await unitOfWork.LibroRepository.GetLibroById(request.Id);

            // Mapeamos el Libro a tipo LibroVM
            return mapper.Map<LibroVM_Complete>(libro);
        }
    }


}
