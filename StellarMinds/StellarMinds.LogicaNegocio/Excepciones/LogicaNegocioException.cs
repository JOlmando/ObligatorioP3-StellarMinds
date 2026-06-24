namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class LogicaNegocioException : Exception

    {
        public LogicaNegocioException()
        {
        }


        public LogicaNegocioException(string? message) : base(message)
        {
        }

        public Error Error()
        {
            return new Error(
                400,
                this.Message ?? string.Empty
            );
        }

    }
}