using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class LoginUsuario : ICULoginUsuario<UsuarioRol>
    {
        private IRepositorioUsuario _repo;
        public LoginUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }
        public UsuarioRol Execute(string username, string password)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new AuthInvalidException("Usuario y/o contraseña vacios");
            }
            if (_repo.LoginUsuario(username, password) == null)
            {
                throw new AuthInvalidException("Usuario y/o contraseña incorrectos");
            }
            return UsuarioMapper.FromRepo(_repo.LoginUsuario(username, password));
        }


    }
}

