namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioGetById<T>
    {
        public T GetById(int id);
    }
}
