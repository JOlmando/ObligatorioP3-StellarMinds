using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO
{
    public record VOPassword
    {
        public string Value { get; private set; }

        public VOPassword(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Value) || Value.Length < 8)
            {
                throw new PasswordInvalidException("El password debe tener al menos 8 caracteres");
            }

            if (!Value.Any(char.IsUpper))
            {
                throw new PasswordInvalidException("El password debe incluir al menos una letra mayúscula");
            }

            if (!Value.Any(char.IsLower))
            {
                throw new PasswordInvalidException("El password debe incluir al menos una letra minúscula");
            }

            if (!Value.Any(char.IsDigit))
            {
                throw new PasswordInvalidException("El password debe incluir al menos un número");
            }

            if (!Value.Any(c => !char.IsLetterOrDigit(c)))
            {
                throw new PasswordInvalidException("El password debe incluir al menos un carácter especial");
            }
        }
    }
}
