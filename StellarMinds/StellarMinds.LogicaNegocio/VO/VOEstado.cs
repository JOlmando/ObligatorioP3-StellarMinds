using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO
{
    public record VOEstado
    {
        public Estado Value { get; private set; }

        public enum Estado
        {
            DEVUELTO,
            EN_PRESTAMO
        }

        private VOEstado() { }

        public VOEstado(Estado estado)
        {
            Value = estado;
            Validar();
        }

        public void Validar()
        {
            if (!Enum.IsDefined(typeof(Estado), Value))
            {
                throw new EstadoInvalidException("Estado no válido.");
            }
        }

    }
}
