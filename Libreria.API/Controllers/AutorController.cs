using Libreria.Application.Features.Autores.Commands.Create;
using Libreria.Application.Features.Autores.Commands.Delete;
using Libreria.Application.Features.Autores.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;

namespace Libreria.API.Controllers
{

    [ApiController]
    // Ruta
    [Route("api/V1/[Controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IMediator mediator;

        public AutorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
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

    }
}