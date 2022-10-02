using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Features.Autores.Queries.ViewModels;
using Libreria.Application.Features.Libros.Queries.ViewModels;
using MediatR;

namespace Libreria.Application.Features.Autores.Queries.GetAutorByName
{

    public class GetAutorByNameHandler : IRequestHandler<GetAutorByName, List<AutorVM_Complete>>
    {


        private readonly IUnitOfWork unitOfWork;
        // Mapeo de las entidades
        private readonly IMapper mapper;

        public GetAutorByNameHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<AutorVM_Complete>> Handle(GetAutorByName request, CancellationToken cancellationToken)
        {
            var autores = await unitOfWork.AutorRepository.GetAutorByName(request.Nombre);

            // Mapeamos el autor a tipo AutorVM
            return mapper.Map<List<AutorVM_Complete>>(autores);
        }
    }

}
