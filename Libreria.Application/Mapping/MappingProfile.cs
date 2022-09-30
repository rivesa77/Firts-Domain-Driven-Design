using AutoMapper;
using Libreria.Application.Features.Autores.Commands.Create;
using Libreria.Application.Features.Autores.Commands.Delete;
using Libreria.Application.Features.Autores.Commands.Update;
using Libreria.Application.Features.Editoriales.Commands.Create;
using Libreria.Application.Features.Editoriales.Commands.Delete;
using Libreria.Application.Features.Editoriales.Commands.Update;
using Libreria.Application.Features.Generos.Commands.Create;
using Libreria.Application.Features.Generos.Commands.Delete;
using Libreria.Application.Features.Generos.Commands.Update;
using Libreria.Application.Features.Libros.Commands.Create;
using Libreria.Application.Features.Libros.Commands.Delete;
using Libreria.Application.Features.Libros.Commands.Update;
using Libreria.Domain;

namespace Libreria.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo de entidad
            
            // Autor
            CreateMap<CreateAutorCommand, Autor>();
            CreateMap<UpdateAutorCommand, Autor>();
            CreateMap<DeleteAutorCommand, Autor>();


            // Autor
            CreateMap<CreateGeneroCommand, Genero>();
            CreateMap<UpdateGeneroCommand, Genero>();
            CreateMap<DeleteGeneroCommand, Genero>();

            // Autor
            CreateMap<CreateLibroCommand, Libro>();
            CreateMap<UpdateLibroCommand, Libro>();
            CreateMap<DeleteLibroCommand, Libro>();

            // Autor
            CreateMap<CreateEditorialCommand, Editorial>();
            CreateMap<UpdateEditorialCommand, Editorial>();
            CreateMap<DeleteEditorialCommand, Editorial>();



        }
    }
}
