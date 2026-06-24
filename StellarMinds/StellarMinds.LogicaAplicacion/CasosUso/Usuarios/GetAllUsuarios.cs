using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetAllUsuarios(IRepositorioUsuario _repo) : ICUGetAll<GetUsuarioDto>
    {
        public IEnumerable<GetUsuarioDto> Execute()
        {
            return UsuarioMapper.ToListDto(_repo.GetAll());
        }
    }
}
