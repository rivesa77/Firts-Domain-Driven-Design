using Libreria.API.Error;
using Libreria.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace Libreria.API.Middleware
{
    public class ExceptionMiddleware
    {
        //Esta clase formatea el error de VS a Json para que sea generico

        // Representa el pipeLine que va a continuar hacia la siguiente fase en caso no ocurra ninguna excepcion
        private readonly RequestDelegate next;
        // Loger para guardar la excepcion sobre la clase ExceptionMiddleware
        private readonly ILogger<ExceptionMiddleware> logger;
        // Necesario para saber si que ambiente estamos en Produccion o desarrollo
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Procesa el request que esta enviando el cliente
                await next(context);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var statuscode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;

                switch (ex)
                {

                    case NotFoundException notFoundException:
                        {
                            statuscode = (int)HttpStatusCode.NotFound;
                            break;
                        }

                    case ValidationException validationException:
                        {
                            statuscode = (int)HttpStatusCode.BadRequest;
                            // serializamos a json toda la lista de errores en validacion y la convertimos en Json
                            var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                            result = JsonConvert.SerializeObject(new CodeErrorException(statuscode, ex.Message, validationJson));
                            break;
                        }

                    case BadRequestException badRequestException:
                        {
                            statuscode = (int)HttpStatusCode.BadRequest;
                            break;
                        }

                    default:
                        break;
                }

                if (string.IsNullOrEmpty(result))
                    result = JsonConvert.SerializeObject(new CodeErrorException(statuscode, ex.Message, ex.StackTrace));


                //var response = env.IsDevelopment()
                //    ? new CodeErrorException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                //    : new CodeErrorException((int)HttpStatusCode.InternalServerError);

                //var option = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                //var json = JsonSerializer.Serialize(response, option);
                context.Response.StatusCode = statuscode;
                await context.Response.WriteAsync(result);



            }
        }
    }
}
