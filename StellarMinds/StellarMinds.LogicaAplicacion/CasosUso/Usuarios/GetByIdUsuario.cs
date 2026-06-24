using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetByIdUsuario(IRepositorioUsuario _repo) : ICUGetById<GetUsuarioDto>
    {
        public GetUsuarioDto Execute(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El ID del usuario no puede ser 0");
            }
            return UsuarioMapper.ToDto(_repo.GetById(id));
        }
    }
}
