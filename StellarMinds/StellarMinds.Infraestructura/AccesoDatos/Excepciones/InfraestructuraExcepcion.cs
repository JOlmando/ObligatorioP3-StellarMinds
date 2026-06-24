using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.Infraestructura.AccesoDatos.Excepciones
{
    public abstract class InfraestructuraExcepcion : Exception
    {
        private string _message;

        public InfraestructuraExcepcion()
        {
        }

        public InfraestructuraExcepcion(string? message) : base(message)
        {
            _message = message;
        }


        public abstract int StatusCode();

        public Error Error()
        {
            return new Error(
                StatusCode(),
                this._message ?? string.Empty
            );
        }

    }
}
