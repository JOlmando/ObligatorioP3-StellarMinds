namespace StellarMinds.AppWeb.Models.Dtos.Logs
{
    public record LogPrestamoDto(
        Guid Id,
        int PrestamoId,
        int UsuarioId,
        string NombreCoordinador,
        string Operacion,
        DateTime Fecha
    );
}