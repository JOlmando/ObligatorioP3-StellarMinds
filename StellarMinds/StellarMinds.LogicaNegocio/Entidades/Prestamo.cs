using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Prestamo
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public VOEstado Estado { get; set; }
        public ICollection<PrestamoDetalle> PrestamoDetalles { get; set; }
        private Prestamo()
        {

        }

        public Prestamo(int usuarioId, DateTime fechaInicio, DateTime fechaFin, VOEstado estado)
        {
            UsuarioId = usuarioId;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            PrestamoDetalles = new List<PrestamoDetalle>();
            Estado = estado;
            Validar();
        }

        public void Update(Prestamo obj)
        {
            UsuarioId = obj.UsuarioId;
            FechaInicio = obj.FechaInicio;
            FechaFin = obj.FechaFin;
            PrestamoDetalles = new List<PrestamoDetalle>();
            Estado = obj.Estado;
            Validar();
        }

        public void PrestamoDevuelto()
        {
            Estado = new VOEstado(VOEstado.Estado.DEVUELTO);
        }

        public void Validar()
        {
            if (UsuarioId == 0)
            {
                throw new LogicaNegocioException("El ID del usuario es inválido.");
            }
            if (FechaInicio >= FechaFin)
            {
                throw new LogicaNegocioException("La fecha de inicio es inválida.");
            }


        }
    }
}
