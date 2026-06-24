namespace StellarMinds.LogicaNegocio.VO
{
    public record VOIndicador
    {
        public Indicador Value { get; private set; }

        public enum Indicador
        {
            IDEAL,
            ADECUADO,
            NO_RECOMEDABLE
        }

        public VOIndicador(Indicador value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (!Enum.IsDefined(typeof(Indicador), Value))
            {
                throw new ArgumentException("Valor de indicador no válido.");
            }
        }
    }
}