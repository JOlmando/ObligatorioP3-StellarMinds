using Microsoft.EntityFrameworkCore;
using StellarMinds.Infraestructura.AccesoDatos.EF;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.Infraestructura.AccesoDatos.Repositorios
{
    public class RepositorioEquipo(StellarMindsContext _context) : IRepositorioEquipo
    {
        public int Add(Equipo obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se recibio el equipo");
            }
            obj.Validar();
            _context.Equipos.Add(obj);
            _context.SaveChanges();
            return obj.Id;
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("El ID del equipo no puede ser 0");
            }
            Equipo unEquipo = GetById(id);
            _context.Equipos.Remove(unEquipo);
            _context.SaveChanges();
        }

        public void Update(int id, Equipo obj)
        {
            Equipo unEquipo = GetById(id);
            unEquipo.Update(obj);
            _context.Equipos.Update(unEquipo);
            _context.SaveChanges();
        }

        public void EquipoPrestado(int id, Equipo obj)
        {
            Equipo unEquipo = GetById(id);
            _context.Equipos.Update(unEquipo);
            _context.SaveChanges();
        }

        public void EquipoDevuelto(int id, Equipo obj)
        {
            Equipo unEquipo = GetById(id);
            _context.Equipos.Update(unEquipo);
            _context.SaveChanges();
        }

        public IEnumerable<Equipo> GetAll()
        {
            IEnumerable<Equipo> aux = _context.Equipos
                                              //.OrderBy(equipo => equipo.Marca.Value)
                                              .ToList();
            return aux;
        }

        public IEnumerable<Telescopio> GetAllTelescopios()
        {
            IEnumerable<Telescopio> aux = _context.Telescopios.ToList();
            return aux;
        }

        public Equipo GetById(int id)
        {
            Equipo unEquipo = _context.Equipos.Find(id);
            if (unEquipo == null)
            {
                throw new Exception($"No se encontro el equipo {id}");
            }
            return unEquipo;
        }

        public List<Equipo> GetEquiposByPid(int prestamoId)
        {
            //List<Equipo> aux = _context.PrestamoDetalles.Where(p => p.PrestamoId == prestamoId).Include(p => p.Equipo).ToList();

            List<Equipo> aux = _context.PrestamoDetalles.Where(p => p.PrestamoId == prestamoId)
                                                        .Include(p => p.Equipo)
                                                        .Select(p => p.Equipo)
                                                        .ToList();
            return aux;
        }
    }
}
