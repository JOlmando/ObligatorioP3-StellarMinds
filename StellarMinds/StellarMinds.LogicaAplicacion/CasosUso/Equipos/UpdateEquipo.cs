using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class UpdateEquipo(IRepositorioEquipo _repo) : ICUUpdate<EquiposDto>
    {
        public void Execute(int id, EquiposDto Obj)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id de equipo invalido");
            }
            _repo.Update(id, EquipoMapper.FromDto(Obj));
        }
    }
}
