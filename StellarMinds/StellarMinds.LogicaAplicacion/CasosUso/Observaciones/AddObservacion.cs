using StellarMinds.LogicaAplicacion.Dtos.Observacion;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Observaciones
{
    public class AddObservacion(IRepositorioObservacion _repo) : ICUAdd<ObservacionAltaDto>
    {
        public int Execute(ObservacionAltaDto obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("La observación no puede ser null");
            }
            return _repo.Add(ObservacionMapper.FromDto(obj));
        }
    }
}
