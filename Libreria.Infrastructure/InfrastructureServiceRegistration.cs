using Libreria.Application.Contracts.Persistence;
using Libreria.Infrastructure.Persistence;
using Libreria.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Libreria.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibreriaDbContext>(option =>
                    option.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ILibroRepository, LibroRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IEditorialRepository, EditorialRepository>();
            services.AddScoped<ILibroAutorRepository, LibroAutorRepository>();
            services.AddScoped<ILibroGeneroRepository, LibroGeneroRepository>();

            return services;
        }
    }
}