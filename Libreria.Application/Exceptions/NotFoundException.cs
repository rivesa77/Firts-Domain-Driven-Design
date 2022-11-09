namespace Libreria.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        //public NotFoundException(string message, object key) : base($"Entity \"{message}\" ({key}) no fue encontrado")
        public NotFoundException(string message, object key) : base($"Entidad ({key}) no existe en la BD" + Environment.NewLine)
        {
        }
    }
}