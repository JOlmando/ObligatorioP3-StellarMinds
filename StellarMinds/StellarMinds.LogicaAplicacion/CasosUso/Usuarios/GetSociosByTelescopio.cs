using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetSociosByTelescopio(IRepositorioUsuario _repo) : ICUGetById<IEnumerable<GetUsuarioDto>>
    {
        public IEnumerable<GetUsuarioDto> Execute(int telescopioId)
        {
            if (telescopioId < 0)
            {
                throw new ArgumentException("El ID del telescopio es invalido");
            }
            return UsuarioMapper.ToListDto(_repo.GetSociosByTelescopio(telescopioId));
        }
    }
}
