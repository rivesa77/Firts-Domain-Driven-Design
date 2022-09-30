namespace Libreria.API.Error
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? detail { get; set; }

        public CodeErrorException(int status, string? message = null, string? detail = null) : base(status, message)
        {
            this.detail = detail;
        }
    }
}
