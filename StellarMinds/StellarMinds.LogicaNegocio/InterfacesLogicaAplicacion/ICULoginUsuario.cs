namespace StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICULoginUsuario<T>
    {
        public T Execute(string username, string password);
    }
}
