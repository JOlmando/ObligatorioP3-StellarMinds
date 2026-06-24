using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class UpdateUsuario(IRepositorioUsuario _repo) : ICUUpdate<UsuarioAltaDto>
    {
        public void Execute(int id, UsuarioAltaDto Obj)
        {
            if (id < 0)
            {
                throw new ArgumentException("El ID del usuario no puede ser 0");
            }
            if (Obj == null)
            {
                throw new ArgumentException("El usuario a modificar es null");
            }
            _repo.Update(id, UsuarioMapper.FromDto(Obj));
        }
    }
}
