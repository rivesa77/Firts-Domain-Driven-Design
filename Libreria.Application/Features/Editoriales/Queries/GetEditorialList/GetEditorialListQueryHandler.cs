using AutoMapper;
using Libreria.Application.Contracts.Persistence;
using Libreria.Application.Features.Editoriales.Queries.ViewModels;
using Libreria.Domain;
using MediatR;
using System.Linq.Expressions;

namespace Libreria.Application.Features.Editoriales.Queries.GetEditorialList
{


    public class GetEditorialListQueryHandler : IRequestHandler<GetEditorialListQuery, List<EditorialVM_Complete>>
    {

        private readonly IUnitOfWork unitOfWork;
        // Mapeo de las entidades
        private readonly IMapper mapper;

        public GetEditorialListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<EditorialVM_Complete>> Handle(GetEditorialListQuery request, CancellationToken cancellationToken)
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
            return mapper.Map<List<EditorialVM_Complete>>(editoriales);
        }
    }

}
