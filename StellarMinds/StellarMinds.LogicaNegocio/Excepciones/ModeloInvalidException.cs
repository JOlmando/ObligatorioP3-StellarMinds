namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class ModeloInvalidException : LogicaNegocioException
    {
        public ModeloInvalidException()
        {
        }

        public ModeloInvalidException(string? message) : base(message)
        {
        }

    }
}