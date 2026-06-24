using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO
{
    public record VOCantidadDisponible
    {
        public int Value { get; private set; }

        public VOCantidadDisponible(int value)
        {

            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (Value <= 0)
            {
                throw new CantidadDisponibleInvalidException("Para dar de alta un equipo la cantidad debe ser mayor que cero");
            }
        }
    }
}
