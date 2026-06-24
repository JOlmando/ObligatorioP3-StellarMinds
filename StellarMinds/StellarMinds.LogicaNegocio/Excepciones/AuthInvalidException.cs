namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class AuthInvalidException : LogicaNegocioException
    {
        public AuthInvalidException()
        {
        }

        public AuthInvalidException(string? message) : base(message)
        {
        }

    }
}