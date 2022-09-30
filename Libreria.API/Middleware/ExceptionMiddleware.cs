using Libreria.API.Error;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

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
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = env.IsDevelopment()
                    ? new CodeErrorException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                    : new CodeErrorException((int)HttpStatusCode.InternalServerError);

                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, option);
                await context.Response.WriteAsync(json);



            }
        }
    }
}
