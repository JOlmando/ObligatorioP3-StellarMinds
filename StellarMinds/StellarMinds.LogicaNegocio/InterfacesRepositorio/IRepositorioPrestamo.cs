using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPrestamo :
        IRepositorioAdd<Prestamo>,
        IRepositorioGetAll<Prestamo>,
        IRepositorioDelete<Prestamo>,
        IRepositorioUpdate<Prestamo>,
        IRepositorioGetById<Prestamo>,
        IRepositorioGetByUserId<Prestamo>
    {
        public List<Prestamo> GetByUserId(int idUser);

        public List<Prestamo> GetPrestamosTodosByUserId(int idUser);
    }
}
