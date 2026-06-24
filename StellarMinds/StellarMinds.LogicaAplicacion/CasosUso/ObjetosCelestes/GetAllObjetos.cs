using StellarMinds.LogicaAplicacion.Dtos.ObjetoCeleste;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.ObjetosCelestes
{
    public class GetAllObjetos(IRepositorioObjetoCeleste _repo) : ICUGetAll<ObjetoDto>
    {
        public IEnumerable<ObjetoDto> Execute()
        {
            return ObjetoCelesteMapper.ToListDto(_repo.GetAll());
        }
    }
}
