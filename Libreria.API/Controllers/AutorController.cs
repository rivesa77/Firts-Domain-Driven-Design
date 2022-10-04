using Libreria.Application.Features.Autores.Commands.Create;
using Libreria.Application.Features.Autores.Commands.Delete;
using Libreria.Application.Features.Autores.Commands.Update;
using Libreria.Application.Features.Autores.Queries.GetAutorByName;
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
    public class AutorController : ControllerBase
    {
        private readonly IMediator mediator;

        public AutorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

 
        [HttpPost(Name = "CreateAutor")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAutor([FromBody] CreateAutorCommand command)
        {
            return await mediator.Send(command);
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
        [HttpPut(Name = "UpdateAutor")]
        // definicion de los posible resultados 
        [ProducesResponseType(StatusCodes.Status200OK)] // OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] // No encontrado el registro 
        [ProducesDefaultResponseType]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateAutor([FromBody] UpdateAutorCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
        [HttpDelete("{id}", Name = "DeleteAutor")]
        // definicion de los posible resultados 
        [ProducesResponseType(StatusCodes.Status204NoContent)] // No contenido el registro a eliminar
        [ProducesResponseType(StatusCodes.Status404NotFound)] // No encontrado el registro a eliminar
        [ProducesDefaultResponseType]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteAutor(int id)
        {
            var command = new DeleteAutorCommand
            {
                Id = id
            };
            await mediator.Send(command);
            return Ok();
        }

        [SwaggerOperation(
            Summary = "Obtiene todos las entidades Autor que contengan el nombre ",
            Description = "Devuelve Autor con las entidades Libro,Genero y Editorial asociadas a Autor",
            OperationId = "GetAutorByName"
        )]
        [HttpGet("Query/GetAutorByName/{nombre}", Name = "GetAutorByName")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType(typeof(IEnumerable<Autor>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutorByName(string nombre)
        {
            var query = new GetAutorByName(nombre);
            // envio de la query a la capa aplication
            var autores = await mediator.Send(query);

            return Ok(autores);
        }

    }
}