using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO
{
    public record VOModelo
    {
        public string Value { get; private set; }

        public VOModelo(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value) || Value.Length < 3)
            {
                throw new ModeloInvalidException("El modelo debe tener al menos 3 caracteres");
            }
        }
    }
}
