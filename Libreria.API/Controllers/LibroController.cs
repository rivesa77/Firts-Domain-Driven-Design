using Libreria.Application.Features.Libros.Commands.Create;
using Libreria.Application.Features.Libros.Commands.Delete;
using Libreria.Application.Features.Libros.Commands.Update;
using Libreria.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Libreria.Infrastructure.Repositories;
using Libreria.Application.Features.Libros.Queries.GetLibrosList;
using Libreria.Application.Features.Libros.Queries.GetLibrosAutorByTitle;
using Libreria.Application.Features.Libros.Queries.ViewModels;

namespace Libreria.API.Controllers
{

    [ApiController]
    // Ruta
    [Route("api/V1/[Controller]")]
    public class LibroController : ControllerBase
    {
        private readonly IMediator mediator;

        public LibroController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
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


        [HttpGet( Name = "GetLibroList")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType(typeof(IEnumerable<Libro>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Libro>>> getLibrosList()
        {
            var query = new GetLibrosListQuery();
            // envio de la query a la capa aplication
            var Libros = await mediator.Send(query);
            
            return Ok(Libros);
        }

        [HttpGet("{titulo}",Name = "GetLibrosAutorByTitle")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType(typeof(IEnumerable<Libro>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibrosAutorByTitle(string titulo)
        {
            var query = new GetLibrosAutorByTitle(titulo);
            // envio de la query a la capa aplication
            var Libros = await mediator.Send(query);

            return Ok(Libros);
        }

    }
}
