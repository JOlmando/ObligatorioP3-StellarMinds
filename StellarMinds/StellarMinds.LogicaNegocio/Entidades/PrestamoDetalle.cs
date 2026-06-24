using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class PrestamoDetalle
    {
        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; }
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }

        private PrestamoDetalle()
        {

        }

        public PrestamoDetalle(int prestamoId, int equipoId)
        {
            PrestamoId = prestamoId;
            EquipoId = equipoId;
            Validar();
        }

        public void Update(PrestamoDetalle obj)
        {
            PrestamoId = obj.PrestamoId;
            EquipoId = obj.EquipoId;
        }

        public void Validar()
        {
            if (PrestamoId < 0)
            {
                throw new LogicaNegocioException("Prestamo id no puede ser negativo");

            }
            if (EquipoId < 0)
            {
                throw new LogicaNegocioException("Equipo id no puede ser negativo");
            }
        }
    }

}
