namespace StellarMinds.AppWeb.Models.Dtos.Usuarios
{
    public record UsuarioModificarDto(
        int Id,
        string UserName,
        string Name,
        string Email,
        string Calle,
        int NumeroPuerta,
        int Apartamento,
        TipoRol Rol
    );
}
