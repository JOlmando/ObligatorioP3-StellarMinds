using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class AddEquipo(IRepositorioEquipo _repo) : ICUAdd<EquiposDto>
    {
        public int Execute(EquiposDto equipoDto)
        {
            if (equipoDto == null)
            {
                throw new ArgumentNullException("El equipo no puede ser null");
            }
            return _repo.Add(EquipoMapper.FromDto(equipoDto));
        }
    }
}
