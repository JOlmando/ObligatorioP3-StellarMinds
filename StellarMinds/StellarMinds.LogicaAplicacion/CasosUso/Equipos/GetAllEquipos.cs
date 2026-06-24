using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class GetAllEquipos : ICUGetAll<EquiposDto>
    {
        private IRepositorioEquipo _repo;
        public GetAllEquipos(IRepositorioEquipo repo)
        {
            _repo = repo;
        }
        public IEnumerable<EquiposDto> Execute()
        {
            return EquipoMapper.ToListDto(_repo.GetAll());
        }


    }
}
