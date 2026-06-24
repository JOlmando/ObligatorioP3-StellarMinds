using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO
{
    public record VOAddress
    {
        public string Calle { get; private set; }
        public int NumeroPuerta { get; private set; }
        public int Apartamento { get; private set; }

        public VOAddress(string calle, int numeroPuerta, int apartamento)
        {
            Calle = calle;
            NumeroPuerta = numeroPuerta;
            Apartamento = apartamento;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Calle))
            {
                throw new DireccionInvalidException("La calle no puede estar vacía.");
            }

            if (NumeroPuerta <= 0)
            {
                throw new DireccionInvalidException("El número de puerta debe ser mayor que cero.");
            }
        }
    }
}
