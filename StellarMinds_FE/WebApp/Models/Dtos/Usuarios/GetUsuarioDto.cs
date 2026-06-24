using static StellarMinds.AppWeb.Models.Dtos.Usuarios.GetUsuarioDto;

namespace StellarMinds.AppWeb.Models.Dtos.Usuarios
{
    public record GetUsuarioDto(
        int Id,
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