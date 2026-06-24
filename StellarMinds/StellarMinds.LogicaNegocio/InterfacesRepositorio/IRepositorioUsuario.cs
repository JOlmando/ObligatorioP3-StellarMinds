using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario :
        IRepositorioAdd<Usuario>,
        IRepositorioGetAll<Usuario>,
        IRepositorioDelete<Usuario>,
        IRepositorioUpdate<Usuario>,
        IRepositorioGetById<Usuario>,
        IRepositorioLoginUsuario<Usuario>
    {
        public IEnumerable<Socio> GetAllSocios();

        public List<Socio> GetSociosByTelescopio(int telescopioId);


    }
}