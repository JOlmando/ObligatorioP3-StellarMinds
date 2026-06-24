namespace StellarMinds.LogicaAplicacion.CasosUso.Logs
{
    public interface ICUGetAuditoriaPrestamos<T>
    {
        T Execute(int? usuarioId);
    }
}
