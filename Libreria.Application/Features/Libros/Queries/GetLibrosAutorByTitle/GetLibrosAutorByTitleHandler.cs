using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using MediatR;

namespace Libreria.Application.Features.Libros.Queries.GetLibrosAutorByTitle
{

    public class GetLibrosAutorByTitleHandler : IRequestHandler<GetLibrosAutorByTitle, List<LibroVM>>
    {


        private readonly IUnitOfWork unitOfWork;
        // Mapeo de las entidades
        private readonly IMapper mapper;

        public GetLibrosAutorByTitleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<LibroVM>> Handle(GetLibrosAutorByTitle request, CancellationToken cancellationToken)
        {
            var libro = await unitOfWork.LibroRepository.GetLibrosAutorByTitle(request.Titulo);

            // Mapeamos el Libro a tipo LibroVM
            return mapper.Map<List<LibroVM>>(libro);
        }
    }

}
