namespace StellarMinds.LogicaAplicacion.Dtos.Prestamo
{

    public record PrestamoDto(int id,
                              int usuarioId,
                              DateTime fechaInicio,
                              DateTime fechaFin,
                              int estado,
                              IEnumerable<PDetalleEquiposDto> detallesEquipos)
    {
    }
}
