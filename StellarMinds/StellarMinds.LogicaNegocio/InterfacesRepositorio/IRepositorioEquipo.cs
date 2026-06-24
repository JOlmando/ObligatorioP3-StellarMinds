using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEquipo :
        IRepositorioAdd<Equipo>,
        IRepositorioGetAll<Equipo>,
        IRepositorioDelete<Equipo>,
        IRepositorioUpdate<Equipo>,
        IRepositorioGetById<Equipo>
    {
        public IEnumerable<Telescopio> GetAllTelescopios();
        public void EquipoPrestado(int id, Equipo equipo);
        public void EquipoDevuelto(int id, Equipo equipo);

        public List<Equipo> GetEquiposByPid(int prestamoId);
    }
}
