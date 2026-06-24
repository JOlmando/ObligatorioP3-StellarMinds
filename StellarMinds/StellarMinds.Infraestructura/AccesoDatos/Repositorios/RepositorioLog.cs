using StellarMinds.Infraestructura.AccesoDatos.EF;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

public class RepositorioLog : IRepositorioLog
{
    private StellarMindsContext _context;

    public RepositorioLog(StellarMindsContext context)
    {
        _context = context;
    }

    public Guid Add(Log obj)
    {
        _context.Logs.Add(obj);
        _context.SaveChanges();
        return obj.Id;
    }

    public IEnumerable<Log> GetAll()
    {
        return _context.Logs.ToList();
    }

}