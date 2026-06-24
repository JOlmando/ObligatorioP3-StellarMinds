using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class EquipoMapper
    {
        //VOMarca marca, VOModelo modelo, VOCantidadDisponible cantidadDisponible
        public static Equipo FromDto(EquiposDto equipoDto)
        {
            if (equipoDto == null)
            {
                throw new Exception("El equipo no puede ser nulo");
            }

            if (equipoDto.tipoEquipo.CompareTo(EquiposDto.TipoEquipo.Telescopio) == 0)
            {
                return new Telescopio(new VOMarca(equipoDto.marca),
                                      new VOModelo(equipoDto.modelo),
                                      new VOCantidadDisponible(equipoDto.cantidadDisponible),
                                      equipoDto.peso,
                                      equipoDto.distanciaFocal,
                                      equipoDto.apertura,
                                      equipoDto.relacionFocal);
            }
            else if (equipoDto.tipoEquipo.CompareTo(EquiposDto.TipoEquipo.Montura) == 0)
            {
                return new Montura(new VOMarca(equipoDto.marca),
                                      new VOModelo(equipoDto.modelo),
                                      new VOCantidadDisponible(equipoDto.cantidadDisponible),
                                      equipoDto.cargaUtil,
                                      equipoDto.esComputarizado,
                                      new VOTipoMontura((VOTipoMontura.TipoMontura)equipoDto.tipoMontura));
            }
            else if (equipoDto.tipoEquipo.CompareTo(EquiposDto.TipoEquipo.Camara) == 0)
            {
                return new Camara(new VOMarca(equipoDto.marca),
                                      new VOModelo(equipoDto.modelo),
                                      new VOCantidadDisponible(equipoDto.cantidadDisponible),
                                      new VOTipoSensor((VOTipoSensor.TipoSensor)equipoDto.tipoSensor),
                                      equipoDto.resolucion,
                                      equipoDto.tamanioPixel);
            }
            else if (equipoDto.tipoEquipo.CompareTo(EquiposDto.TipoEquipo.Ocular) == 0)
            {
                return new Ocular(new VOMarca(equipoDto.marca),
                                      new VOModelo(equipoDto.modelo),
                                      new VOCantidadDisponible(equipoDto.cantidadDisponible),
                                      equipoDto.diametro,
                                      equipoDto.anguloVision);
            }
            else
            {
                throw new Exception("El tipo de equipo no es válido");
            }
        }

        public static EquiposDto ToDto(Equipo equipo)
        {
            if (equipo == null)
            {
                throw new Exception("El equipo no puede ser nulo");
            }
            if (equipo is Telescopio telescopio)
            {
                return new EquiposDto(equipo.Id,
                                      equipo.Marca.Value,
                                      equipo.Modelo.Value,
                                      equipo.CantidadDisponible.Value,
                                      equipo.StockSinUSo,
                                      EquiposDto.TipoEquipo.Telescopio,
                                      tipoSensor: 0,
                                      resolucion: 0,
                                      tamanioPixel: 0,
                                      cargaUtil: 0,
                                      esComputarizado: false,
                                      tipoMontura: 0,
                                      diametro: 0,
                                      anguloVision: 0,
                                      apertura: telescopio.Apertura,
                                      relacionFocal: telescopio.RelacionFocal,
                                      peso: telescopio.Peso,
                                      distanciaFocal: telescopio.DistanciaFocal
                );
            }
            else if (equipo is Montura montura)
            {
                return new EquiposDto(equipo.Id,
                    equipo.Marca.Value,
                                      equipo.Modelo.Value,
                                      equipo.CantidadDisponible.Value,
                                      equipo.StockSinUSo,
                                      EquiposDto.TipoEquipo.Montura,
                                      tipoSensor: 0,
                                      resolucion: 0,
                                      tamanioPixel: 0,
                                      cargaUtil: montura.CargaUtil,
                                      esComputarizado: montura.EsComputarizado,
                                      tipoMontura: (int)montura.TipoMontura.Value,
                                      diametro: 0,
                                      anguloVision: 0,
                                      apertura: 0,
                                      relacionFocal: string.Empty,
                                      peso: 0,
                                      distanciaFocal: 0
                );
            }
            else if (equipo is Camara camara)
            {
                return new EquiposDto(equipo.Id,
                                      equipo.Marca.Value,
                                      equipo.Modelo.Value,
                                      equipo.CantidadDisponible.Value,
                                      equipo.StockSinUSo,
                                      EquiposDto.TipoEquipo.Camara,
                                      tipoSensor: (int)camara.TipoSensor.Value,
                                      resolucion: camara.Resolucion,
                                      tamanioPixel: camara.TamañoPixel,
                                      cargaUtil: 0,
                                      esComputarizado: false,
                                      tipoMontura: 0,
                                      diametro: 0,
                                      anguloVision: 0,
                                      apertura: 0,
                                      relacionFocal: string.Empty,
                                      peso: 0,
                                      distanciaFocal: 0
                );
            }
            else if (equipo is Ocular ocular)
            {
                return new EquiposDto(equipo.Id,
                                      equipo.Marca.Value,
                                      equipo.Modelo.Value,
                                      equipo.CantidadDisponible.Value,
                                      equipo.StockSinUSo,
                                      EquiposDto.TipoEquipo.Ocular,
                                      tipoSensor: 0,
                                      resolucion: 0,
                                      tamanioPixel: 0,
                                      cargaUtil: 0,
                                      esComputarizado: false,
                                      tipoMontura: 0,
                                      diametro: ocular.Diametro,
                                      anguloVision: ocular.AnguloVision,
                                      apertura: 0,
                                      relacionFocal: string.Empty,
                                      peso: 0,
                                      distanciaFocal: 0
                );
            }
            else
            {
                throw new Exception("El tipo de equipo no es válido");
            }
        }


        /*
        public static EquipoAbstractDto ToDtoAbstract(Equipo equipo)
        {
            if (equipo == null)
            {
                throw new Exception("El equipo no puede ser nulo");
            }
            if (equipo is Telescopio telescopio)
            {
                return new TelescopioDto(telescopio.Id,
                                         telescopio.Marca.Value,
                                         telescopio.Modelo.Value,
                                         telescopio.CantidadDisponible.Value,
                                         telescopio.Peso,
                                         telescopio.DistanciaFocal,
                                         telescopio.Apertura,
                                         telescopio.RelacionFocal);
            }
            else if (equipo is Montura montura)
            {
                return new MonturaDto(montura.Id,
                                      montura.Marca.Value,
                                      montura.Modelo.Value,
                                      montura.CantidadDisponible.Value,
                                      montura.CargaUtil,
                                      montura.EsComputarizado,
                                      (int)montura.TipoMontura.Value);
            }
            else if (equipo is Camara camara)
            {
                return new CamaraDto(camara.Id,
                                      camara.Marca.Value,
                                      camara.Modelo.Value,
                                      camara.CantidadDisponible.Value,
                                      (int)camara.TipoSensor.Value,
                                      camara.Resolucion,
                                      camara.TamañoPixel);
            }
            else if (equipo is Ocular ocular)
            {
                return new OcularDto(ocular.Id,
                                      ocular.Marca.Value,
                                      ocular.Modelo.Value,
                                      ocular.CantidadDisponible.Value,
                                      ocular.Diametro,
                                      ocular.AnguloVision);
            }
            else
            {
                throw new Exception("El tipo de equipo no es válido");
            }
        }
        */

        public static IEnumerable<EquiposDto> ToListDto(IEnumerable<Equipo> equipos)
        {
            List<EquiposDto> equiposDto = new List<EquiposDto>();
            foreach (var item in equipos)
            {
                equiposDto.Add(ToDto(item));
            }
            return equiposDto;
        }
    }
}