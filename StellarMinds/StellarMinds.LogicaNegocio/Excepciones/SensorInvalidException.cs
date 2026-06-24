namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class SensorInvalidException : LogicaNegocioException
    {
        public SensorInvalidException()
        {
        }

        public SensorInvalidException(string? message) : base(message)
        {
        }
    }
}
