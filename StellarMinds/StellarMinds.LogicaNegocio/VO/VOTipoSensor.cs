namespace StellarMinds.LogicaNegocio.VO
{
    public record VOTipoSensor
    {
        public TipoSensor Value { get; private set; }

        public enum TipoSensor
        {
            CMOS,
            CCD
        }

        public VOTipoSensor(TipoSensor value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (!Enum.IsDefined(typeof(TipoSensor), Value))
            {
                throw new ArgumentException("Tipo de sensor no válido.");
            }
        }
    }
}