using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Features.Libros.Queries.ViewModels;
using MediatR;

namespace Libreria.Application.Features.Libros.Queries.GetLibrosAutorByTitle
{

    public class GetLibrosAutorByTitleHandler : IRequestHandler<GetLibrosAutorByTitle, List<LibroVM_Complete>>
    {


        private readonly IUnitOfWork unitOfWork;
        // Mapeo de las entidades
        private readonly IMapper mapper;

        public GetLibrosAutorByTitleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<LibroVM_Complete>> Handle(GetLibrosAutorByTitle request, CancellationToken cancellationToken)
        {
            var libros = await unitOfWork.LibroRepository.GetLibrosAutorByTitle(request.Titulo);

            // Mapeamos el Libro a tipo LibroVM
            return mapper.Map<List<LibroVM_Complete>>(libros);
        }
    }

}
