using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class UsuarioMapper
    {
        public static Usuario FromDto(UsuarioAltaDto usuarioDto)
        {

            if (usuarioDto == null)
            {
                throw new Exception("El usuario no puede ser nulo");
            }
            if (usuarioDto.Rol.CompareTo(UsuarioAltaDto.TipoRol.Administrador) == 0)
            {
                return new Administrador(new VOUserName(usuarioDto.UserName),
                                         new VOName(usuarioDto.Name),
                                         new VOEmail(usuarioDto.Email),
                                         new VOAddress(usuarioDto.Calle, usuarioDto.NumeroPuerta, usuarioDto.Apartamento),
                                         new VOPassword(usuarioDto.Password));
            }
            else if (usuarioDto.Rol.CompareTo(UsuarioAltaDto.TipoRol.Coordinador) == 0)
            {
                return new Coordinador(new VOUserName(usuarioDto.UserName),
                                       new VOName(usuarioDto.Name),
                                       new VOEmail(usuarioDto.Email),
                                       new VOAddress(usuarioDto.Calle, usuarioDto.NumeroPuerta, usuarioDto.Apartamento),
                                       new VOPassword(usuarioDto.Password));
            }
            else if (usuarioDto.Rol.CompareTo(UsuarioAltaDto.TipoRol.Socio) == 0)
            {
                return new Socio(new VOUserName(usuarioDto.UserName),
                                 new VOName(usuarioDto.Name),
                                 new VOEmail(usuarioDto.Email),
                                 new VOAddress(usuarioDto.Calle, usuarioDto.NumeroPuerta, usuarioDto.Apartamento),
                                 new VOPassword(usuarioDto.Password));
            }
            else
            {
                throw new Exception("El rol del usuario no es válido");
            }

        }

        public static GetUsuarioDto ToDto(Usuario usuario)
        {
            return new GetUsuarioDto(usuario.Id,
                                     usuario.UserName.Value,
                                     usuario.Name.Value,
                                     usuario.Email.Value,
                                     usuario.Adress.Calle,
                                     usuario.Adress.NumeroPuerta,
                                     usuario.Adress.Apartamento,
                                     usuario.Password.Value,
                                     (GetUsuarioDto.TipoRol)Enum.Parse(typeof(GetUsuarioDto.TipoRol), usuario.GetRol()));
        }



        public static IEnumerable<GetUsuarioDto> ToListDto(IEnumerable<Usuario> usuarios)
        {
            List<GetUsuarioDto> usuariosDto = new List<GetUsuarioDto>();
            foreach (var item in usuarios)
            {
                usuariosDto.Add(ToDto(item));
            }
            return usuariosDto;
        }


        public static UsuarioRol FromRepo(Usuario usuario)
        {
            return new UsuarioRol(usuario.Id,
                                  usuario.UserName.Value,
                                  usuario.Password.Value,
                                  usuario.GetRol()
                                  );
        }

        //public static GetUsuarioDto ToDtoListado(Usuario usuario)
        //{
        //    return new GetUsuarioDto(usuario.Id,
        //                             usuario.Name.Value,
        //                             usuario.UserName.Value,
        //                             usuario.Email.Value
        //                                 );
        //}

        //public static UsuarioAltaDto ToDtoAlta(Usuario usuario)
        //{
        //    return new UsuarioAltaDto(usuario.Name.Value,
        //                            usuario.NumeroReferencia,
        //                            usuario.Direccion.Calle,
        //                            usuario.Direccion.Apartamento,
        //                            usuario.Direccion.NumeroPuerta,
        //                            usuario.Email.Value);
        //}

        //public static IEnumerable<GetUsuarioDto> ToListDto(IEnumerable<Usuario> usuarios)
        //{
        //    List<GetUsuarioDto> usuariosListadoDto = new List<GetUsuarioDto>();
        //    foreach (var usuario in usuarios)
        //    {
        //        usuariosListadoDto.Add(ToDtoListado(usuario));
        //    }
        //    return usuariosListadoDto;
        //}
    }
}
