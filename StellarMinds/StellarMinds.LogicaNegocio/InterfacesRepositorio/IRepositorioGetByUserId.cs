namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioGetByUserId<T>
    {
        public List<T> GetByUserId(int id);
    }
}
