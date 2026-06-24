namespace StellarMinds.LogicaAplicacion.Dtos.Prestamo
{
    public record PrestamoAltaDto(int idUsuario,
                                  DateTime fechaInicio,
                                  DateTime fechaFin,
                                  IEnumerable<int> idEquipos,
                                  int idCoordinador)
    {
    }
}
