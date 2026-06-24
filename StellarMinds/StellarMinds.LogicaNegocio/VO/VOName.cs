using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO
{
    public record VOName
    {
        public string Value { get; private set; }

        public VOName(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (Value == null || Value.Length < 3)
            {
                throw new NameInvalidException("El nombre debe tener mas de 3 letras");
            }

        }
    }
}
