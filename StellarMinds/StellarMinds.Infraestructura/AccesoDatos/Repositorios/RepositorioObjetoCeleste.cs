using StellarMinds.Infraestructura.AccesoDatos.EF;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.Infraestructura.AccesoDatos.Repositorios
{
    public class RepositorioObjetoCeleste(StellarMindsContext _context) : IRepositorioObjetoCeleste
    {
        public int Add(ObjetoCeleste obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObjetoCeleste> GetAll()
        {
            IEnumerable<ObjetoCeleste> aux = _context.ObjetosCeleste.ToList();
            return aux;
        }

        public ObjetoCeleste GetById(int id)
        {
            ObjetoCeleste unObjeto = _context.ObjetosCeleste.Find(id);
            if (unObjeto == null)
            {
                throw new Exception($"No se encontro el objeto celeste {id}");
            }
            return unObjeto;
        }

        public void Update(int id, ObjetoCeleste obj)
        {
            throw new NotImplementedException();
        }
    }
}
