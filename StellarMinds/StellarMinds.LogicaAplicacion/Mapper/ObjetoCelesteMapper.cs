using StellarMinds.LogicaAplicacion.Dtos.ObjetoCeleste;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class ObjetoCelesteMapper
    {
        public static ObjetoDto ToDto(ObjetoCeleste objeto)
        {
            return new ObjetoDto(objeto.Id,
                                 objeto.Nombre.Value,
                                 objeto.MagnitudAparente,
                                 objeto.TipoCeleste);

        }
        public static ObjetoCeleste FromDto(ObjetoDto objeto)
        {
            return new ObjetoCeleste(new VOName(objeto.nombre),
                                     objeto.magnitudAparente,
                                     objeto.tipo);
        }

        public static IEnumerable<ObjetoDto> ToListDto(IEnumerable<ObjetoCeleste> objetos)
        {
            List<ObjetoDto> objetosDto = new List<ObjetoDto>();
            foreach (var item in objetos)
            {
                objetosDto.Add(ToDto(item));
            }
            return objetosDto;
        }
    }
}
