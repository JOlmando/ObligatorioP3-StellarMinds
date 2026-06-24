using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class GetlAllTelescopios(IRepositorioEquipo _repo) : ICUGetAllTelescopios<EquiposDto>
    {
        public IEnumerable<EquiposDto> Execute()
        {
            return EquipoMapper.ToListDto(_repo.GetAllTelescopios());
        }
    }
}
