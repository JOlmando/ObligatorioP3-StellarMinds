using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPrestamoDetalle :
        IRepositorioAdd<PrestamoDetalle>,
        IRepositorioGetAll<PrestamoDetalle>,
        IRepositorioDelete<PrestamoDetalle>,
        IRepositorioUpdate<PrestamoDetalle>,
        IRepositorioGetById<PrestamoDetalle>
    {

        public List<PrestamoDetalle> GetAllByPrestamoId(int prestamoId);
    }
}
