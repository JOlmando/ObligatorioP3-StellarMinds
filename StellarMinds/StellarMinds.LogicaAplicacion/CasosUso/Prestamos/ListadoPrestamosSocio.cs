using StellarMinds.LogicaAplicacion.Dtos.Prestamo;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaAplicacion.CasosUso.Prestamos
{
    public class ListadoPrestamosSocio(IRepositorioPrestamo _repo) : ICUListadoPrestamosSocio<IEnumerable<PrestamoListadoDto>>
    {
        public IEnumerable<PrestamoListadoDto> Execute(int usuarioId, int mes, int anio)
        {
            if (mes < 0 || anio < 0)
            {
                throw new ArgumentException("Argumentos de mes y/o año invalidos");
            }
            if (usuarioId < 0)
            {
                throw new ArgumentException("Usuario invalidos");
            }
            var prestamos = _repo.GetPrestamosTodosByUserId(usuarioId);

            prestamos = prestamos
                .Where(p =>
                    p.FechaInicio.Month == mes &&
                    p.FechaInicio.Year == anio)
                .ToList();

            return prestamos.Select(p =>
                new PrestamoListadoDto(
                    p.Id,
                    p.FechaInicio,
                    p.FechaFin,
                    p.Estado.Value.ToString(),
                    p.Estado.Value == VOEstado.Estado.EN_PRESTAMO
                        && DateTime.Now > p.FechaFin
                ));
        }
    }
}