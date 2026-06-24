namespace StellarMinds.LogicaNegocio.Excepciones
{

    public class MarcaInvalidException : LogicaNegocioException
    {
        public MarcaInvalidException()
        {
        }

        public MarcaInvalidException(string? message) : base(message)
        {
        }

    }
}