using Libreria.Application.Features.Generos.Commands.Create;
using Libreria.Application.Features.Generos.Commands.Delete;
using Libreria.Application.Features.Generos.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;

namespace Libreria.API.Controllers
{
    [ApiController]
    // Ruta
    [Route("api/V1/[Controller]")]
    public class GeneroController : ControllerBase
    {
        private readonly IMediator mediator;

        public GeneroController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
        [HttpPost(Name = "CreateGenero")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateGenero([FromBody] CreateGeneroCommand command)
        {
            return await mediator.Send(command);
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
        [HttpPut(Name = "UpdateGenero")]
        // definicion de los posible resultados 
        [ProducesResponseType(StatusCodes.Status200OK)] // OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] // No encontrado el registro 
        [ProducesDefaultResponseType]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateStreamer([FromBody] UpdateGeneroCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
        [HttpDelete("{id}", Name = "DeleteGenero")]
        // definicion de los posible resultados 
        [ProducesResponseType(StatusCodes.Status204NoContent)] // No contenido el registro a eliminar
        [ProducesResponseType(StatusCodes.Status404NotFound)] // No encontrado el registro a eliminar
        [ProducesDefaultResponseType]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteStreamer(int id)
        {
            var command = new DeleteGeneroCommand
            {
                Id = id
            };
            await mediator.Send(command);
            return Ok();
        }

    }
}
