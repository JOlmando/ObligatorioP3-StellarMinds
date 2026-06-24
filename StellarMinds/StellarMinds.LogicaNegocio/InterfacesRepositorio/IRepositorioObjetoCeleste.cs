using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioObjetoCeleste :
        IRepositorioAdd<ObjetoCeleste>,
        IRepositorioGetAll<ObjetoCeleste>,
        IRepositorioDelete<ObjetoCeleste>,
        IRepositorioUpdate<ObjetoCeleste>,
        IRepositorioGetById<ObjetoCeleste>
    {
    }
}
