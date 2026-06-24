using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Montura : Equipo
    {
        public decimal? CargaUtil { get; set; }
        public bool? EsComputarizado { get; set; }
        public VOTipoMontura? TipoMontura { get; set; }
        private Montura() { }

        public Montura(VOMarca marca,
                       VOModelo modelo,
                       VOCantidadDisponible cantidadDisponible,
                       decimal? cargaUtil,
                       bool? esComputarizado,
                       VOTipoMontura? tipoMontura) : base(marca, modelo, cantidadDisponible)
        {
            CargaUtil = cargaUtil;
            EsComputarizado = esComputarizado;
            TipoMontura = tipoMontura;
            Validar();
        }
        public override void Validar()
        {
            base.Validar();
            if (CargaUtil < 0 || TipoMontura == null)
            {
                throw new LogicaNegocioException("Carga Util, Tipo de Montura y Computarizado son obligatorios");
            }
        }

        public override void Update(Equipo obj)
        {
            base.Update(obj);
            if (obj is Montura montura)
            {
                CargaUtil = montura.CargaUtil;
                EsComputarizado = montura.EsComputarizado;
                TipoMontura = montura.TipoMontura;
                Validar();
            }
            else
            {
                throw new LogicaNegocioException("El objeto a actualizar no es una montura");
            }
        }

        public override string GetNombre()
        {
            return "Montura";
        }

    }

}