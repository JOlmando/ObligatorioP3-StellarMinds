using StellarMinds.LogicaAplicacion.Dtos.Observacion;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Observaciones
{
    public class GetByIdObservacion(IRepositorioObservacion _repo) : ICUGetById<ObservacionAltaDto>
    {
        public ObservacionAltaDto Execute(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id de observacion invalido");
            }
            return ObservacionMapper.ToDto(_repo.GetById(id));
        }
    }
}
