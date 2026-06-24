namespace StellarMinds.Infraestructura.AccesoDatos.Excepciones
{
    public class BadRequestException : InfraestructuraExcepcion
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string? message) : base(message)
        {
        }

        public override int StatusCode()
        {
            return 400;
        }
    }
}
