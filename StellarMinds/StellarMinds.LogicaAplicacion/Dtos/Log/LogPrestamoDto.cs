namespace StellarMinds.LogicaAplicacion.Dtos.Logs
{
    public record LogPrestamoDto(
        Guid Id,
        int PrestamoId,
        int UsuarioId,
        string Operacion,
        DateTime Fecha
    );
}