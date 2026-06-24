namespace StellarMinds.AppWeb.Models.Dtos.Prestamos
{
    public record PrestamoDto(
        int Id,
        int UsuarioId,
        DateTime FechaInicio,
        DateTime FechaFin,
        int Estado,
        IEnumerable<PrestamoDetalleDto> DetallesEquipos
    );
}