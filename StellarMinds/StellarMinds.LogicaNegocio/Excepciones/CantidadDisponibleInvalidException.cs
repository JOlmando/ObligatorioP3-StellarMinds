namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class CantidadDisponibleInvalidException : LogicaNegocioException
    {
        public CantidadDisponibleInvalidException()
        {
        }

        public CantidadDisponibleInvalidException(string? message) : base(message)
        {
        }

    }
}