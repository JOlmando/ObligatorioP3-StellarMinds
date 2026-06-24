using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public abstract class Equipo
    {
        public int Id { get; set; }
        public VOMarca Marca { get; set; }
        public VOModelo Modelo { get; set; }
        public VOCantidadDisponible CantidadDisponible { get; set; }
        public int StockSinUSo { get; set; }
        public ICollection<PrestamoDetalle> PrestamoDetalles { get; set; }
        protected Equipo()
        {

        }

        public Equipo(VOMarca marca,
                      VOModelo modelo,
                      VOCantidadDisponible cantidadDisponible)
        {
            Marca = marca;
            Modelo = modelo;
            CantidadDisponible = cantidadDisponible;
            PrestamoDetalles = new List<PrestamoDetalle>();
            StockSinUSo = CantidadDisponible.Value;
        }

        public virtual void Validar()
        {
            if (Marca == null || Modelo == null || CantidadDisponible == null)
            {
                throw new LogicaNegocioException("Marca, Modelo y Cantidad Disponible son obligatorios");
            }
            if (CantidadDisponible.Value < 0)
            {
                throw new LogicaNegocioException("La cantidad disponible no puede ser negativa");
            }
            if (CantidadDisponible.Value < StockSinUSo)
            {
                throw new LogicaNegocioException("El stock sin uso de un equipo no puede ser mayor a la cantidad disponible");
            }

        }

        public virtual void Update(Equipo obj)
        {
            Marca = obj.Marca;
            Modelo = obj.Modelo;
            CantidadDisponible = obj.CantidadDisponible;
            StockSinUSo = obj.StockSinUSo;
            Validar();
        }

        public abstract string GetNombre();

        public virtual void EquipoPrestado(Equipo obj)
        {
            obj.StockSinUSo = StockSinUSo - 1;
            Validar();
        }

        public void EquipoDevuelto(Equipo obj)
        {
            obj.StockSinUSo = StockSinUSo + 1;
            Validar();
        }
    }
}