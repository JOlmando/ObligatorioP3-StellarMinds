using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Camara : Equipo
    {
        public VOTipoSensor TipoSensor { get; set; }
        public int? Resolucion { get; set; }
        public int? TamañoPixel { get; set; }


        public Camara(VOMarca marca,
                      VOModelo modelo,
                      VOCantidadDisponible cantidadDisponible,
                      VOTipoSensor tipoSensor,
                      int? resolucion,
                      int? tamañoPixel) : base(marca, modelo, cantidadDisponible)
        {
            TipoSensor = tipoSensor;
            Resolucion = resolucion;
            TamañoPixel = tamañoPixel;
            Validar();
        }

        private Camara() { }

        public override void Validar()
        {
            base.Validar();
            if (TipoSensor == null || Resolucion < 0 || TamañoPixel < 0)
            {
                throw new LogicaNegocioException("Tipo de Sensor, Resolución y Tamaño de Pixel son obligatorios");
            }
        }

        public override void Update(Equipo obj)
        {
            base.Update(obj);
            if (obj is Camara camara)
            {
                TipoSensor = camara.TipoSensor;
                Resolucion = camara.Resolucion;
                TamañoPixel = camara.TamañoPixel;
                Validar();
            }
            else
            {
                throw new LogicaNegocioException("El objeto a actualizar no es una cámara");
            }
        }

        public override string GetNombre()
        {
            return "Camara";
        }
    }
}
