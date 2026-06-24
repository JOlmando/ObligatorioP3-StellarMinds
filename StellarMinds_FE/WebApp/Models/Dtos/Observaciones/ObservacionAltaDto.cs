namespace StellarMinds.AppWeb.Models.Dtos.Observaciones
{
    public record ObservacionAltaDto(
        DateTime FechaObs,
        int PrestamoId,
        string Indicador,
        string? Detalle,
        int ObjetoCelesteId
    );
}