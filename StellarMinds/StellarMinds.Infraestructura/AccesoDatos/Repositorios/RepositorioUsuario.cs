using StellarMinds.Infraestructura.AccesoDatos.EF;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.Infraestructura.AccesoDatos.Repositorios
{
    public class RepositorioUsuario(StellarMindsContext _context) : IRepositorioUsuario
    {
        public Usuario LoginUsuario(string username, string password)
        {

            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.UserName.Value == username && u.Password.Value == password);
            if (usuario == null)
            {
                throw new AuthInvalidException("Credenciales inválidas");
            }
            return usuario;
        }



        public int Add(Usuario obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se recibio el usuario");
            }
            obj.Validar();
            _context.Usuarios.Add(obj);
            _context.SaveChanges();
            return obj.Id;
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("El ID del equipo no puede ser 0");
            }
            Usuario unUsuario = GetById(id);
            _context.Usuarios.Remove(unUsuario);
            _context.SaveChanges();
        }

        public void Update(int id, Usuario obj)
        {
            Usuario unUsuario = GetById(id);
            unUsuario.Update(obj);
            _context.Usuarios.Update(unUsuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            IEnumerable<Usuario> aux = _context.Usuarios.ToList();
            return aux;
        }

        public IEnumerable<Socio> GetAllSocios()
        {
            IEnumerable<Socio> aux = _context.Socios.ToList();
            return aux;
        }

        public List<Socio> GetSociosByTelescopio(int telescopioId)
        {

            List<Socio> socios = _context.Equipos.Where(e => e.Id == telescopioId)
                                                        .Join(_context.PrestamoDetalles,
                                                            e => e.Id,
                                                            pd => pd.EquipoId,
                                                            (e, pd) => pd)
                                                        .Join(_context.Prestamos,
                                                            pd => pd.PrestamoId,
                                                            p => p.Id,
                                                            (pd, p) => p)
                                                        .Join(_context.Socios,
                                                            p => p.UsuarioId,
                                                            u => u.Id,
                                                            (p, u) => u)
                                                        .Distinct()
                                                        .OrderByDescending(u => u.Name.Value).ToList();

            return socios;
        }

        public Usuario GetById(int id)
        {
            Usuario unUsuario = _context.Usuarios.Find(id);
            if (unUsuario == null)
            {
                throw new Exception($"No se encontro el usuario {id}");
            }
            return unUsuario;
        }
    }
}
