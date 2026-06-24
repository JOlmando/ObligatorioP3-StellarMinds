namespace StellarMinds.Infraestructura.AccesoDatos.Excepciones
{
    public class NotFoundException : InfraestructuraExcepcion
    {

        public NotFoundException() { }

        public NotFoundException(string? message) : base(message)
        {
        }

        public override int StatusCode()
        {
            return 404;
        }
    }
}
