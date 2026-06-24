
namespace StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface IJwtGenerator<T>
    {
        string GenerateToken(T usuario);
    }
}
