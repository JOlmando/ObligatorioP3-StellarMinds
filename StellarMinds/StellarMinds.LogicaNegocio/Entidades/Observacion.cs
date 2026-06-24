namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Observacion
    {
        public int Id { get; set; }
        public DateTime FechaObs { get; set; }
        public Prestamo Prestamo { get; set; }
        public int PrestamoId { get; set; }
        public string Indicador { get; set; }
        public string Detalle { get; set; }
        public ObjetoCeleste ObjetoCeleste { get; set; }
        public int ObjetoCelesteId { get; set; }

        private Observacion() { }

        public Observacion(DateTime fechaObs, int prestamoId, string indicador, string detalle, int objetoCelesteId)
        {
            FechaObs = fechaObs;
            PrestamoId = prestamoId;
            Indicador = indicador;
            Detalle = detalle;
            ObjetoCelesteId = objetoCelesteId;
            Validar();
        }

        private void Validar()
        {
            if (PrestamoId < 0)
            {
                throw new LockRecursionException("El id del prestamo no puede ser negativo o 0");
            }

        }

    }
}
