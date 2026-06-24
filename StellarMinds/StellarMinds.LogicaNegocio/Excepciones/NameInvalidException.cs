

namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class NameInvalidException : LogicaNegocioException
    {
        public NameInvalidException()
        {
        }

        public NameInvalidException(string? message) : base(message)
        {
        }
    }
}
