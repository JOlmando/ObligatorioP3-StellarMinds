using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class GetEquiposByPid(IRepositorioEquipo _repo) : ICUGetById<IEnumerable<EquiposDto>>
    {
        public IEnumerable<EquiposDto> Execute(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id de equipo invalido");
            }
            return EquipoMapper.ToListDto(_repo.GetEquiposByPid(id));
        }
    }
}
