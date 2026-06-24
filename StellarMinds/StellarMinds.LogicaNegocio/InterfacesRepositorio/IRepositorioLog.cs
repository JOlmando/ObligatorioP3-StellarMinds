using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    // Log entity uses Guid identifiers; do not inherit IRepositorioAdd<T> which assumes int return.
    public interface IRepositorioLog
    {
        System.Guid Add(Log obj);
        IEnumerable<Log> GetAll();
    }
}
