using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Features.Libros.Queries.ViewModels;
using MediatR;

namespace Libreria.Application.Features.Libros.Queries.GetLibrosList
{
    public class GetLibrosListQueryHandler : IRequestHandler<GetLibrosListQuery, List<LibroVM_Complete>>
    {
        private readonly IUnitOfWork unitOfWork;

        // Mapeo de las entidades
        private readonly IMapper mapper;

        public GetLibrosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<LibroVM_Complete>> Handle(GetLibrosListQuery request, CancellationToken cancellationToken)
        {
            var libroList = await unitOfWork.LibroRepository.GetLibrosList();

            // Mapeamos el Libro a tipo LibroVM
            return mapper.Map<List<LibroVM_Complete>>(libroList);
        }
    }
}