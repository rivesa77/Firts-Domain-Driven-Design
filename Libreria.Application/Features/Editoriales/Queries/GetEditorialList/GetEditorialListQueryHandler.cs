using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Features.Editoriales.Queries.ViewModels;
using Libreria.Application.Features.Libros.Queries.GetLibrosList;
using Libreria.Application.Features.Libros.Queries.ViewModels;
using Libreria.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Editoriales.Queries.GetEditorialList
{


    public class GetEditorialListQueryHandler : IRequestHandler<GetEditorialListQuery, List<EditorialVM>>
    {


        private readonly IUnitOfWork unitOfWork;
        // Mapeo de las entidades
        private readonly IMapper mapper;

        public GetEditorialListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<EditorialVM>> Handle(GetEditorialListQuery request, CancellationToken cancellationToken)
        {
            var includes = new List<Expression<Func<Editorial, object>>>();
            includes.Add(p => p.Libros!);
            var editoriales = await unitOfWork.Repository<Editorial>().GetAsync(

                 null,
                 b => b.OrderBy(x => x.CreatedDate),
                 includes,
                 true

                 );

            // Mapeamos el video a tipo VideoVM
            return mapper.Map<List<EditorialVM>>(editoriales);
        }
    }

}
