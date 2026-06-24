namespace StellarMinds.LogicaNegocio.VO
{
    public record VOTipoMontura
    {
        public TipoMontura Value { get; private set; }

        public enum TipoMontura
        {
            Altazimutal,
            Ecuatorial,
            Hibrida
        }

        public VOTipoMontura(TipoMontura value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (!Enum.IsDefined(typeof(TipoMontura), Value))
            {
                throw new ArgumentException("Tipo de montura no válida.");
            }
        }
    }
}

