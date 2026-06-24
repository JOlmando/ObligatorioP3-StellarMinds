namespace StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUGetById<T>
    {
        public T Execute(int id);
    }
}
