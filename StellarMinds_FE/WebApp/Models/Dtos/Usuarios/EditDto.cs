namespace StellarMinds.AppWeb.Models.Dtos.Usuarios
{
    public class EditDto(int Id,
        string UserName,
        string Name,
        string Email,
        string Calle,
        int NumeroPuerta,
        int Apartamento,
        string Password,
        TipoRol Rol
    );

    public enum TipoRol
    {
        Administrador,
        Coordinador,
        Socio
    }
}
