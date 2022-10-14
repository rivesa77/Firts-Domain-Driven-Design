using Libreria.Application.Features.Editoriales.Queries.ViewModels;
using Libreria.Application.Features.Libros.Queries.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Features.Editoriales.Queries.GetEditorialList
{
    public class GetEditorialListQuery : IRequest<List<EditorialVM_Complete>>
    {
    }
}
