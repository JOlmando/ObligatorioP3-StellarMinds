using static StellarMinds.AppWeb.Models.Dtos.Usuarios.UsuarioAltaDto;

namespace StellarMinds.AppWeb.Models.Dtos.Usuarios
{
    public record UsuarioAltaDto(
                                 string UserName,
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