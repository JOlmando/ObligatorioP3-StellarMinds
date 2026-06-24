namespace StellarMinds.AppWeb.Models.Dtos.Prestamos
{
    public record PrestamoAltaDto(
    int idUsuario,
    int idCoordinador,
    DateTime fechaInicio,
    DateTime fechaFin,
    IEnumerable<int> idEquipos
);
}
