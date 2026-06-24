namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class DireccionInvalidException : LogicaNegocioException
    {
        public DireccionInvalidException()
        {
        }

        public DireccionInvalidException(string? message) : base(message)
        {
        }

    }
}