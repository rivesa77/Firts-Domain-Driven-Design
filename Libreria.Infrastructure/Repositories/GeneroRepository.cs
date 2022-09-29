using Libreria.Application.Contracts.Persistence;
using Libreria.Domain;
using Libreria.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Infrastructure.Repositories
{

    public class GeneroRepository : RepositoryBase<Genero>, IGeneroRepository
    {
        public GeneroRepository(LibreriaDbContext context) : base(context)
        {

        }
    }

}
