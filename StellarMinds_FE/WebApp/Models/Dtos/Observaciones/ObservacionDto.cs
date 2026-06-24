namespace StellarMinds.AppWeb.Models.Dtos.Observaciones
{
    public record ObservacionDto(
        int Id,
        DateTime FechaObs,
        int PrestamoId,
        int Indicador,
        string Detalle,
        int ObjetoCelesteId
    );
}