namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioGetAll<T>
    {
        public IEnumerable<T> GetAll();
    }
}