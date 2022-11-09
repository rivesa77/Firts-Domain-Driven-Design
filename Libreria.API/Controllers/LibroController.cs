using Libreria.Application.Features.Libros.Commands.Create;
using Libreria.Application.Features.Libros.Commands.Delete;
using Libreria.Application.Features.Libros.Commands.Update;
using Libreria.Application.Features.Libros.Queries.GetLibroById;
using Libreria.Application.Features.Libros.Queries.GetLibrosByTitle;
using Libreria.Application.Features.Libros.Queries.GetLibrosList;
using Libreria.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Libreria.API.Controllers
{
    [ApiController]
    // Ruta
    [Route("api/Libreria/[Controller]")]
    public class LibroController : ControllerBase
    {
        private readonly IMediator mediator;

        public LibroController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [SwaggerOperation(
             Summary = "Alta para un nuevo libro pero obligando a que asigne el IdAutor y el IdGenero",
             Description = "Genera el Libro ,la Relacion LibroAutor y la relacion LibroGenero",
             OperationId = "CreateAutor"
         )]
        [HttpPost(Name = "CreateLibro")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateLibro([FromBody] CreateLibroCommand command)
        {
            return await mediator.Send(command);
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
        [HttpPut(Name = "UpdateLibro")]
        // definicion de los posible resultados
        [ProducesResponseType(StatusCodes.Status200OK)] // OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] // No encontrado el registro
        [ProducesDefaultResponseType]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateLibro([FromBody] UpdateLibroCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
        [HttpDelete("{id}", Name = "DeleteLibro")]
        // definicion de los posible resultados
        [ProducesResponseType(StatusCodes.Status204NoContent)] // No contenido el registro a eliminar
        [ProducesResponseType(StatusCodes.Status404NotFound)] // No encontrado el registro a eliminar
        [ProducesDefaultResponseType]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteLibro(int id)
        {
            var command = new DeleteLibroCommand
            {
                Id = id
            };
            await mediator.Send(command);
            return Ok();
        }

        [SwaggerOperation(
            Summary = "Obtiene todos las entidades Libro ",
            Description = "Devuelve Libro con todas sus entidades relacionadas cargadas",
            OperationId = "GetLibroList"
        )]
        [HttpGet(Name = "Query/GetLibroList")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType(typeof(IEnumerable<Libro>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Libro>>> getLibrosList()
        {
            var query = new GetLibrosListQuery();
            // envio de la query a la capa aplication
            var Libros = await mediator.Send(query);

            return Ok(Libros);
        }

        [SwaggerOperation(
            Summary = "Obtiene entidad Libro que contenga el titulo",
            Description = "Devuelve Libro con solo con la entidad Autor Completa",
            OperationId = "GetLibrosByTitle"
        )]
        [HttpGet("Query/GetLibrosByTitle/{titulo}", Name = "GetLibrosByTitle")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType(typeof(IEnumerable<Libro>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibrosByTitle(string titulo)
        {
            var query = new GetLibrosByTitle(titulo);
            // envio de la query a la capa aplication
            var Libros = await mediator.Send(query);

            return Ok(Libros);
        }

        [SwaggerOperation(
            Summary = "Obtiene entidad Libro por Id",
            Description = "Devuelve Libro con todas sus entidades relacionadas cargadas",
            OperationId = "GetLibroById"
        )]
        [HttpGet("Query/GetLibroById/{Id}", Name = "GetLibroById")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType(typeof(Libro), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Libro>> GetLibroById(int Id)
        {
            var query = new GetLibroById(Id);
            // envio de la query a la capa aplication
            var Libro = await mediator.Send(query);

            return Ok(Libro);
        }
    }
}