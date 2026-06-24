namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class EmailInvalidException : LogicaNegocioException
    {
        public EmailInvalidException()
        {
        }

        public EmailInvalidException(string? message) : base(message)
        {
        }
    }
}