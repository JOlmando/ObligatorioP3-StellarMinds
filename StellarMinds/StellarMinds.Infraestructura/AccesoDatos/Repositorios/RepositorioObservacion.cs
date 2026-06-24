using Microsoft.EntityFrameworkCore;
using StellarMinds.Infraestructura.AccesoDatos.EF;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.Infraestructura.AccesoDatos.Repositorios
{
    public class RepositorioObservacion(StellarMindsContext _context) : IRepositorioObservacion
    {
        public int Add(Observacion obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se recibio la observacion");
            }
            _context.Observaciones.Add(obj);
            _context.SaveChanges();
            return obj.Id;
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("El ID del equipo no puede ser 0");
            }
            Observacion unaObservacion = GetById(id);
            _context.Observaciones.Remove(unaObservacion);
            _context.SaveChanges();
        }

        public IEnumerable<Observacion> GetAll()
        {
            return _context.Observaciones
                .Include(o => o.ObjetoCeleste)
                .ToList();
        }

        public Observacion GetById(int id)
        {
            Observacion unaObservacion = _context.Observaciones.Find(id);
            if (unaObservacion == null)
            {
                throw new Exception($"No se encontro la observacion {id}");
            }
            return unaObservacion;
        }


        public void Update(int id, Observacion obj)
        {
            throw new NotImplementedException();
        }

    }
}
