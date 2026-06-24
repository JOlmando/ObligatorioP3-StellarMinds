namespace StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUGetAllById<T> : IEnumerable<T>
    {
        public T Execute(int id);
    }
}
