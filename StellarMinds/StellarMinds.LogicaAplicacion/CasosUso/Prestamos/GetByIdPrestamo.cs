
using StellarMinds.LogicaAplicacion.Dtos.Prestamo;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;


namespace StellarMinds.LogicaAplicacion.CasosUso.Prestamos
{
    public class GetByIdPrestamo(IRepositorioPrestamo _repo) : ICUGetById<PrestamoDto>
    {
        public PrestamoDto Execute(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del prestamo no puede ser 0 o negativo");
            }
            return PrestamoMapper.ToDto(_repo.GetById(id));
        }
    }
}