using AutoMapper;
using Libreria.Application.Features.Autores.Commands.Create;
using Libreria.Application.Features.Autores.Commands.Delete;
using Libreria.Application.Features.Autores.Commands.Update;
using Libreria.Application.Features.Editoriales.Commands.Create;
using Libreria.Application.Features.Generos.Commands.Create;
using Libreria.Application.Features.Libros.Commands.Create;
using Libreria.Domain;

namespace Libreria.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo de entidad
            //CreateMap<Libro, LibroVM>();
            // Mapeo de command
            CreateMap<CreateLibroCommand, Libro>();
            CreateMap<CreateGeneroCommand, Genero>();
            CreateMap<CreateEditorialCommand, Editorial>();
            
            
            // Autor
            CreateMap<CreateAutorCommand, Autor>();
            CreateMap<UpdateAutorCommand, Autor>();
            CreateMap<DeleteAutorCommand, Autor>();


        }
    }
}
