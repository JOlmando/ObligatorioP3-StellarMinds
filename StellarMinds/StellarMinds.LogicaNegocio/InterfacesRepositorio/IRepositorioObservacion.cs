using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioObservacion :
        IRepositorioAdd<Observacion>,
        IRepositorioGetAll<Observacion>,
        IRepositorioDelete<Observacion>,
        IRepositorioUpdate<Observacion>,
        IRepositorioGetById<Observacion>
    {
    }
}
