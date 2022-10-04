using Libreria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Contracts.Persistence
{
    public interface ILibroGeneroRepository : IAsyncRepository<LibroGenero>
    {
    }
}
