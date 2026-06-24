using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class DeleteUsuario(IRepositorioUsuario _repo) : ICUDelete<UsuarioDeleteDto>
    {
        public void Execute(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El ID del usuario no puede ser 0");
            }
            _repo.Delete(id);
        }
    }
}
