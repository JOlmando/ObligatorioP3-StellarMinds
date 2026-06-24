using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class DeleteEquipo(IRepositorioEquipo _repo) : ICUDelete<EquipoDeleteDto>
    {
        public void Execute(int id)
        {
            if (id == 0)
            {
                throw new LogicaNegocioException("El ID del equipo no puede ser 0");
            }
            _repo.Delete(id);
        }
    }
}
