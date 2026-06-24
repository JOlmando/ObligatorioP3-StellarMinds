namespace StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUGetAll<T>
    {
        public IEnumerable<T> Execute();
    }
}