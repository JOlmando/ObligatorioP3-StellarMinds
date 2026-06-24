namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class PasswordInvalidException : LogicaNegocioException
    {
        public PasswordInvalidException()
        {
        }

        public PasswordInvalidException(string? message) : base(message)
        {
        }
    }
}