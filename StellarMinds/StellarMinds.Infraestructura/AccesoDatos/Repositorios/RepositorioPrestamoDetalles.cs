using StellarMinds.Infraestructura.AccesoDatos.EF;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.Infraestructura.AccesoDatos.Repositorios
{
    public class RepositorioPrestamoDetalles(StellarMindsContext _context) : IRepositorioPrestamoDetalle
    {
        public int Add(PrestamoDetalle obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se recibio el prestamo detalle");
            }
            _context.PrestamoDetalles.Add(obj);
            _context.SaveChanges();
            return obj.PrestamoId;
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("El ID del prestamo detalle no puede ser 0");
            }
            PrestamoDetalle unPrestamoDetalle = GetById(id);
            _context.PrestamoDetalles.Remove(unPrestamoDetalle);
            _context.SaveChanges();
        }

        public IEnumerable<PrestamoDetalle> GetAll()
        {
            IEnumerable<PrestamoDetalle> aux = _context.PrestamoDetalles
                                             //.OrderBy(equipo => equipo.Marca.Value)
                                             .ToList();
            return aux;
        }

        public List<PrestamoDetalle> GetAllByPrestamoId(int prestamoId)
        {
            List<PrestamoDetalle> aux = _context.PrestamoDetalles
                                             .Where(p => p.PrestamoId == prestamoId)
                                             .ToList();
            return aux;
        }



        public PrestamoDetalle GetById(int id)
        {
            //PrestamoDetalle unPrestamoDetalle = _context.PrestamoDetalles.Find(id);
            PrestamoDetalle unPrestamoDetalle = _context.PrestamoDetalles.Where(p => p.PrestamoId == id).FirstOrDefault();
            if (unPrestamoDetalle == null)
            {
                throw new Exception($"No se encontro el prestamo detalle {id}");
            }
            return unPrestamoDetalle;
        }

        public void Update(int id, PrestamoDetalle obj)
        {
            PrestamoDetalle unPrestamoDetalle = GetById(id);
            unPrestamoDetalle.Update(obj);
            _context.PrestamoDetalles.Update(unPrestamoDetalle);
            _context.SaveChanges();
        }
    }
}
