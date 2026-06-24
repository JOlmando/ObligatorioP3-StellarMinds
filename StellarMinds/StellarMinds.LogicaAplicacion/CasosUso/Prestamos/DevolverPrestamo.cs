using StellarMinds.LogicaAplicacion.Dtos.Prestamo;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Prestamos
{
    public class DevolverPrestamo(IRepositorioPrestamo _repo, IRepositorioEquipo _repoEquipo, IRepositorioPrestamoDetalle _repoPD, IRepositorioLog _repoLog) : ICUUpdate<PrestamoDevolucionDto>
    {
        public void Execute(int idPrestamo, PrestamoDevolucionDto obj)
        {
            Prestamo prestamo = _repo.GetById(idPrestamo);
            if (prestamo.Estado.Value == LogicaNegocio.VO.VOEstado.Estado.DEVUELTO)
            {
                throw new ArgumentException("El prestamo ya ha sido devuelto.");
            }

            List<PrestamoDetalle> prestamoDetalles = _repoPD.GetAllByPrestamoId(prestamo.Id);

            foreach (var idEquipo in prestamoDetalles.Select(pd => pd.EquipoId))
            {
                Equipo equipo = _repoEquipo.GetById(idEquipo);
                equipo.EquipoDevuelto(equipo);
                _repoEquipo.EquipoDevuelto(equipo.Id, equipo);

            }
            prestamo.PrestamoDevuelto();
            _repo.Update(idPrestamo, prestamo);
            _repoLog.Add(new Log("Devolucion", obj.coordinadorId, "Prestamo", idPrestamo));
        }
    }
}
