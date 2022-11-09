using AutoMapper;
using Libreria.Application.Features.Autores.Commands.Create;
using Libreria.Application.Features.Autores.Commands.Delete;
using Libreria.Application.Features.Autores.Commands.Update;
using Libreria.Application.Features.Autores.Queries.ViewModels;
using Libreria.Application.Features.Editoriales.Commands.Create;
using Libreria.Application.Features.Editoriales.Commands.Delete;
using Libreria.Application.Features.Editoriales.Commands.Update;
using Libreria.Application.Features.Editoriales.Queries.ViewModels;
using Libreria.Application.Features.Generos.Commands.Create;
using Libreria.Application.Features.Generos.Commands.Delete;
using Libreria.Application.Features.Generos.Commands.Update;
using Libreria.Application.Features.Generos.Queries.ViewModel;
using Libreria.Application.Features.Libros.Commands.Create;
using Libreria.Application.Features.Libros.Commands.Delete;
using Libreria.Application.Features.Libros.Commands.Update;
using Libreria.Application.Features.Libros.Queries.ViewModels;
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
            CreateMap<Autor, AutorVM_Complete>();
            CreateMap<Autor, AutorVM_Simple>();

            // Genero
            CreateMap<CreateGeneroCommand, Genero>();
            CreateMap<UpdateGeneroCommand, Genero>();
            CreateMap<DeleteGeneroCommand, Genero>();
            CreateMap<Genero, GeneroVM_Simple>();
            CreateMap<Genero, GeneroVM_Complete>();

            // Libro
            CreateMap<CreateLibroCommand, Libro>();
            CreateMap<UpdateLibroCommand, Libro>();
            CreateMap<DeleteLibroCommand, Libro>();
            CreateMap<Libro, LibroVM_Complete>();
            CreateMap<Libro, LibroVM_Simple>();

            // Editorial
            CreateMap<CreateEditorialCommand, Editorial>();
            CreateMap<UpdateEditorialCommand, Editorial>();
            CreateMap<DeleteEditorialCommand, Editorial>();
            CreateMap<Editorial, EditorialVM_Simple>();
            CreateMap<Editorial, EditorialVM_Complete>();
        }
    }
}