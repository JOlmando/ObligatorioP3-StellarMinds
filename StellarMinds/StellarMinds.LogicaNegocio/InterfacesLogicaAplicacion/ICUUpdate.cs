namespace StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUUpdate<T>
    {
        public void Execute(int id, T Obj);

    }
}
