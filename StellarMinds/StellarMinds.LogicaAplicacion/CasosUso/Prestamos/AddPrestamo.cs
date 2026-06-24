using StellarMinds.LogicaAplicacion.Dtos.Prestamo;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Prestamos
{
    public class AddPrestamo(IRepositorioPrestamo _repo, IRepositorioPrestamoDetalle _repoPD, IRepositorioLog _repoLog, IRepositorioEquipo _repoEquipo) : ICUAdd<PrestamoAltaDto>
    {
        public int Execute(PrestamoAltaDto prestamoAltaDto)
        {
            int idPrestamo = _repo.Add(PrestamoMapper.FromDto(prestamoAltaDto));

            if (prestamoAltaDto.idEquipos.Count() == 0)
            {
                throw new ArgumentException("No puede dar de alta un prestamo sin equipos");
            }
            if (prestamoAltaDto.idEquipos.Count() < 3)
            {
                throw new ArgumentException("Fatlan equipos para dar de alta el prestamo");
            }
            foreach (var idEquipo in prestamoAltaDto.idEquipos)
            {
                _repoPD.Add(PrestamoMapper.FromDtoPD(idPrestamo, idEquipo));

                Equipo equipo = _repoEquipo.GetById(idEquipo);

                equipo.EquipoPrestado(equipo);

                _repoEquipo.EquipoPrestado(idEquipo, equipo);

            }
            //(string operation, int usuarioid, string tablaname)
            _repoLog.Add(new Log("Préstamo", prestamoAltaDto.idCoordinador, "Prestamo", idPrestamo));
            return idPrestamo;
        }
    }
}
