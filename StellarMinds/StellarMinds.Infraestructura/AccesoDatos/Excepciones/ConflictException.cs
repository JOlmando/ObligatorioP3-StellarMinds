namespace StellarMinds.Infraestructura.AccesoDatos.Excepciones
{
    public class ConflictException : InfraestructuraExcepcion
    {
        public ConflictException()
        {
        }

        public ConflictException(string? message) : base(message)
        {
        }

        public override int StatusCode()
        {
            return 409;
        }
    }
}
