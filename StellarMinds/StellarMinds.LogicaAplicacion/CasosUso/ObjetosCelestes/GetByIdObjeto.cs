using StellarMinds.LogicaAplicacion.Dtos.ObjetoCeleste;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.ObjetosCelestes
{
    public class GetByIdObjeto(IRepositorioObjetoCeleste _repo) : ICUGetById<ObjetoDto>
    {
        public ObjetoDto Execute(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id de objeto invalido");
            }
            return ObjetoCelesteMapper.ToDto(_repo.GetById(id));
        }
    }
}
