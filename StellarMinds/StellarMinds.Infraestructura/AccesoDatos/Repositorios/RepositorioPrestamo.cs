using Microsoft.EntityFrameworkCore;
using StellarMinds.Infraestructura.AccesoDatos.EF;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.Infraestructura.AccesoDatos.Repositorios
{
    public class RepositorioPrestamo(StellarMindsContext _context) : IRepositorioPrestamo
    {
        public int Add(Prestamo prestamo)
        {
            if (prestamo == null)
            {
                throw new ArgumentException("No se recibio el prestamo");
            }
            _context.Prestamos.Add(prestamo);
            _context.SaveChanges();
            return prestamo.Id;
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("El ID del prestamo no puede ser 0");
            }
            Prestamo unPrestamo = GetById(id);
            _context.Prestamos.Remove(unPrestamo);
            _context.SaveChanges();
        }
        public List<Prestamo> GetByUserId(int idUser)
        {
            return _context.Prestamos
                .Where(p => p.UsuarioId == idUser && p.Estado.Value == VOEstado.Estado.EN_PRESTAMO && p.FechaFin >= DateTime.Now)
                .Include(p => p.PrestamoDetalles)
                .ThenInclude(pd => pd.Equipo)
                .ToList();
        }
        public List<Prestamo> GetPrestamosTodosByUserId(int idUser)
        {
            List<Prestamo> prestamos = _context.Prestamos.Where(prestamo => prestamo.UsuarioId == idUser)
                                                                .Include(p => p.PrestamoDetalles)
                                                                .ThenInclude(pd => pd.Equipo)
                                                                .ToList();
            return prestamos;
        }

        public List<Prestamo> GetAll()
        {
            List<Prestamo> aux = _context.Prestamos.Include(p => p.PrestamoDetalles)
                                                   .ThenInclude(pd => pd.Equipo)
                                                   .ToList();
            return aux;
        }

        public Prestamo GetById(int id)
        {
            Prestamo unPrestamo = _context.Prestamos.Where(prestamo => prestamo.Id == id)
                                                    .Include(p => p.PrestamoDetalles)
                                                    .ThenInclude(pd => pd.Equipo)
                                                    .FirstOrDefault();
            if (unPrestamo == null)
            {
                throw new Exception($"No se encontro el prestamo {id}"); // expecializacion especializada not found 
            }
            return unPrestamo;
        }

        public void Update(int id, Prestamo obj)
        {
            Prestamo unPrestamo = GetById(id);
            unPrestamo.Update(obj);
            _context.Prestamos.Update(unPrestamo);
            _context.SaveChanges();
        }

        IEnumerable<Prestamo> IRepositorioGetAll<Prestamo>.GetAll()
        {
            return GetAll();
        }
    }
}
