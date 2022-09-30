namespace Libreria.API.Error
{
    public class CodeErrorResponse
    {
        // Estructura del mensaje de error para el cliente

        public int Status { get; set; }
        public string? Message { get; set; }

        public CodeErrorResponse(int status, string? message = null)
        {
            Status = status;
            Message = message ?? GetDefaultMessageStatusCode(status);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El request enviado tiene errores",
                401 => "No tienes autorizacion para este recurso",
                404 => "No se encontro el recurso solicitado",
                500 => "Se produjeron errores en el servidor",
                _ => string.Empty
            };
        }
    }
}
