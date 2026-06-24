using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class GetByIdEquipo(IRepositorioEquipo _repo) : ICUGetById<EquiposDto>
    {
        public EquiposDto Execute(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id de equipo invalido");
            }
            return EquipoMapper.ToDto(_repo.GetById(id));
        }
    }
}
