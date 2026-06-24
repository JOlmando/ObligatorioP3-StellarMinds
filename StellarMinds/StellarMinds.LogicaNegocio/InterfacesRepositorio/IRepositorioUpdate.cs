namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUpdate<T>
    {
        public void Update(int id, T obj);
    }
}
