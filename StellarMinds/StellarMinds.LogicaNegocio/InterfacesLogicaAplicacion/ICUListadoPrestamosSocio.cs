namespace StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUListadoPrestamosSocio<T> 
    {
       public T Execute(
            int usuarioId,
            int mes,
            int anio);
    }
}