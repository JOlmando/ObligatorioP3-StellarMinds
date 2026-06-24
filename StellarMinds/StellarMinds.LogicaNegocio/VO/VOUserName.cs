using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO
{
    public record VOUserName
    {

        public string Value { get; private set; }

        public VOUserName(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (Value == null || Value.Length < 3)
            {
                throw new UserNameInvalidException("El nombre de usuario debe tener mas de 3 letras");
            }

        }
    }
}
