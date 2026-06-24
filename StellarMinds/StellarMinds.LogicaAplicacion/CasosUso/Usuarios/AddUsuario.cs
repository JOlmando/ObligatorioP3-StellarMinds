using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;


namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class AddUsuario(IRepositorioUsuario _repo) : ICUAdd<UsuarioAltaDto>
    {
        public int Execute(UsuarioAltaDto usuarioAltaDto)
        {

            if (usuarioAltaDto == null)
            {
                throw new ArgumentNullException("El usuario no puede ser null");
            }

            return _repo.Add(UsuarioMapper.FromDto(usuarioAltaDto));
        }
    }
}
