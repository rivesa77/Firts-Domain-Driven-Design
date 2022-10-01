using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Libros.Queries.GetLibrosList
{


    public class GetLibrosListQueryHandler : IRequestHandler<GetLibrosListQuery, List<LibroVM>>
    {

        
        private readonly IUnitOfWork unitOfWork;
        // Mapeo de las entidades
        private readonly IMapper mapper;

        public GetLibrosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<LibroVM>> Handle(GetLibrosListQuery request, CancellationToken cancellationToken)
        {
            var libroList = await unitOfWork.LibroRepository.GetLibrosListQuery(request.titulo);

            // Mapeamos el Libro a tipo LibroVM
            return mapper.Map<List<LibroVM>>(libroList);
        }
    }


}
