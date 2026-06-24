using StellarMinds.LogicaAplicacion.Dtos.Prestamo;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.Prestamos
{
    public class GetAllPrestamos(IRepositorioPrestamo _repo) : ICUGetAll<PrestamoDto>
    {

        public IEnumerable<PrestamoDto> Execute()
        {
            return PrestamoMapper.ToListDto(_repo.GetAll());
        }
    }
}
