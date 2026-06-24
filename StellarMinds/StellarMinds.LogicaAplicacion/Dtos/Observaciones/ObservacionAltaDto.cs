namespace StellarMinds.LogicaAplicacion.Dtos.Observacion
{
    public record ObservacionAltaDto(int PrestamoId,
                                    DateTime FechaObs,
                                    string Indicador,
                                    string Detalle,
                                    int ObjetoCelesteId)
    {
    }
}
