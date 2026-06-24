using static StellarMinds.LogicaAplicacion.Dtos.Usuarios.UsuarioAltaDto;

namespace StellarMinds.LogicaAplicacion.Dtos.Usuarios
{
    public record UsuarioAltaDto(string UserName,
                                 string Name,
                                 string Email,
                                 string Calle,
                                 int NumeroPuerta,
                                 int Apartamento,
                                 string Password,
                                 TipoRol Rol)

    {

        public enum TipoRol
        {
            Administrador,
            Coordinador,
            Socio
        }
    }
}