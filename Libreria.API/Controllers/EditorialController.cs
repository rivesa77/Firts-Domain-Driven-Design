using Libreria.Application.Features.Editoriales.Commands.Create;
using Libreria.Application.Features.Editoriales.Commands.Delete;
using Libreria.Application.Features.Editoriales.Commands.Update;
using Libreria.Application.Features.Editoriales.Queries.GetEditorialList;
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
    public class EditorialController : ControllerBase
    {
        private readonly IMediator mediator;

        public EditorialController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
        [HttpPost(Name = "CreateEditorial")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateEditorial([FromBody] CreateEditorialCommand command)
        {
            return await mediator.Send(command);
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
        [HttpPut(Name = "UpdateEditorial")]
        // definicion de los posible resultados
        [ProducesResponseType(StatusCodes.Status200OK)] // OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] // No encontrado el registro
        [ProducesDefaultResponseType]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateEditorial([FromBody] UpdateEditorialCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        // Name = Nombre que va tener el metodo para el cliente dentro de la url
        [HttpDelete("{id}", Name = "DeleteEditorial")]
        // definicion de los posible resultados
        [ProducesResponseType(StatusCodes.Status204NoContent)] // No contenido el registro a eliminar
        [ProducesResponseType(StatusCodes.Status404NotFound)] // No encontrado el registro a eliminar
        [ProducesDefaultResponseType]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteEditorial(int id)
        {
            var command = new DeleteEditorialCommand
            {
                Id = id
            };
            await mediator.Send(command);
            return Ok();
        }

        [SwaggerOperation(
            Summary = "Obtiene listado de todas las entidades Editorial",
            Description = "Devuelve Editorial con la entidad Libro mapeada",
            OperationId = "GetEditorialList"
        )]
        [HttpGet(Name = "Query/GetEditorialList")]
        //Tipo de valor a devolver al cliente
        [ProducesResponseType(typeof(IEnumerable<Editorial>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Editorial>>> getEditorialList()
        {
            var query = new GetEditorialListQuery();
            // envio de la query a la capa aplication
            var editorial = await mediator.Send(query);

            return Ok(editorial);
        }
    }
}