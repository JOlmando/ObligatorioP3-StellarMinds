namespace StellarMinds.AppWeb.Models.Dtos.Prestamos
{
    public record PrestamoDtoListado(
        int Id,
        int UsuarioId,
        DateTime FechaInicio,
        DateTime FechaFin,
        string Estado,
        bool EstaAtrasado
    );
}