namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class EstadoInvalidException : LogicaNegocioException
    {
        public EstadoInvalidException() { }

        public EstadoInvalidException(string message) : base(message)
        {
        }

    }
}
