using StellarMinds.LogicaAplicacion.Dtos.Observacion;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class ObservacionMapper
    {
        //public static IEnumerable<PrestamoDto> ToListDto(List<Prestamo> prestamos)
        //{
        //    List<PrestamoDto> prestamosDto = new List<PrestamoDto>();
        //    foreach (var item in prestamos)
        //    {
        //        prestamosDto.Add(ToDto(item));
        //    }
        //    return prestamosDto;
        //}

        public static ObservacionAltaDto ToDto(Observacion observacion)
        {
            return new ObservacionAltaDto(observacion.PrestamoId,
                                          observacion.FechaObs,
                                          observacion.Indicador,
                                          observacion.Detalle,
                                          observacion.ObjetoCelesteId);
        }


        public static Observacion FromDto(ObservacionAltaDto observacionAltaDto)
        {
            return new Observacion(observacionAltaDto.FechaObs,
                                   observacionAltaDto.PrestamoId,
                                   observacionAltaDto.Indicador,
                                   observacionAltaDto.Detalle,
                                   observacionAltaDto.ObjetoCelesteId);
        }
    }
}

