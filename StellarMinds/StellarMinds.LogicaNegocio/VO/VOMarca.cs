using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO
{
    public record VOMarca
    {
        public string Value { get; private set; }

        public VOMarca(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value) || Value.Length < 3)
            {
                throw new MarcaInvalidException("La marca debe tener al menos 3 caracteres");
            }
        }
    }
}
