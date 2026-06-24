namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioLoginUsuario<T>
    {
        public T LoginUsuario(string username, string password);
    }
}
