using Libreria.Application.Features.Editoriales.Queries.ViewModels;
using MediatR;

namespace Libreria.Application.Features.Editoriales.Queries.GetEditorialList
{
    public class GetEditorialListQuery : IRequest<List<EditorialVM_Complete>>
    {
    }
}