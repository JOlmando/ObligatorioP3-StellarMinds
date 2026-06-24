using StellarMinds.LogicaAplicacion.Dtos.Prestamo;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class PrestamoMapper
    {
        public static IEnumerable<PrestamoDto> ToListDto(List<Prestamo> prestamos)
        {
            List<PrestamoDto> prestamosDto = new List<PrestamoDto>();
            foreach (var item in prestamos)
            {
                prestamosDto.Add(ToDto(item));
            }
            return prestamosDto;
        }

        internal static IEnumerable<PrestamoDto> ToListDto(IEnumerable<Prestamo> enumerable)
        {
            List<PrestamoDto> prestamosDto = new List<PrestamoDto>();
            foreach (var item in enumerable)
            {
                prestamosDto.Add(ToDto(item));
            }
            return prestamosDto;
        }

        public static PrestamoDto ToDto(Prestamo prestamo)
        {
            return new PrestamoDto(prestamo.Id,
                                   prestamo.UsuarioId,
                                   prestamo.FechaInicio,
                                   prestamo.FechaFin,
                                   (int)prestamo.Estado.Value,
                                   prestamo.PrestamoDetalles.Select(d => new PDetalleEquiposDto(d.Equipo.Marca.Value, d.Equipo.Modelo.Value, d.Equipo.GetNombre())));
        }


        public static Prestamo FromDto(PrestamoAltaDto prestamoAltaDto)
        {
            return new Prestamo(prestamoAltaDto.idUsuario,
                                prestamoAltaDto.fechaInicio,
                                prestamoAltaDto.fechaFin,
                                new VOEstado(VOEstado.Estado.EN_PRESTAMO));
        }

        public static PrestamoDetalle FromDtoPD(int idPrestamo, int idEquipo)
        {
            return new PrestamoDetalle(idPrestamo, idEquipo);
        }

        public static IEnumerable<PDetalleEquiposDto> ToListDtoPD(List<PrestamoDetalle> prestamos)
        {
            List<PDetalleEquiposDto> prestamosDto = new List<PDetalleEquiposDto>();
            foreach (var item in prestamos)
            {
                prestamosDto.Add(ToDtoPD(item));
            }
            return prestamosDto;
        }

        public static PDetalleEquiposDto ToDtoPD(PrestamoDetalle prestamoDetalle)
        {
            return new PDetalleEquiposDto(prestamoDetalle.Equipo.Marca.Value,
                                          prestamoDetalle.Equipo.Modelo.Value,
                                          prestamoDetalle.Equipo.GetNombre());
        }


    }
}