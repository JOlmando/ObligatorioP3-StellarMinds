using StellarMinds.LogicaAplicacion.Dtos.Prestamo;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Prestamos
{
    public class GetPrestamosByUserId(IRepositorioPrestamo _repo) : ICUGetById<IEnumerable<PrestamoDto>>
    {
        public IEnumerable<PrestamoDto> Execute(int id)
        {
            if (id == 0)
            {
                throw new LogicaNegocioException("El ID del prestamo no puede ser 0");
            }
            return PrestamoMapper.ToListDto(_repo.GetByUserId(id));
        }
    }
}
