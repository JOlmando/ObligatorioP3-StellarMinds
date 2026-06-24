namespace StellarMinds.LogicaAplicacion.Dtos.Prestamo
{
    public record PrestamoListadoDto(
        int Id,
        DateTime FechaInicio,
        DateTime FechaFin,
        string Estado,
        bool EstaAtrasado
    );
}