namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class UserNameInvalidException : LogicaNegocioException
    {
        public UserNameInvalidException()
        {
        }

        public UserNameInvalidException(string? message) : base(message)
        {
        }
    }
}
