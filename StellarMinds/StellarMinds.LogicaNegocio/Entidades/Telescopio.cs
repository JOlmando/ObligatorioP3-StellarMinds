using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Telescopio : Equipo
    {
        public int? Apertura { get; set; }
        public string? RelacionFocal { get; set; }
        public decimal? Peso { get; set; }
        public int? DistanciaFocal { get; set; }

        private Telescopio() { }

        public Telescopio(VOMarca marca,
                          VOModelo modelo,
                          VOCantidadDisponible cantidadDisponible,
                          decimal? peso,
                          int? distanciaFocal,
                          int? apertura,
                          string? relacionFocal) : base(marca, modelo, cantidadDisponible)
        {
            Peso = peso;
            DistanciaFocal = distanciaFocal;
            Apertura = apertura;
            RelacionFocal = relacionFocal;
            Validar();
        }

        public override void Validar()
        {
            base.Validar();
            if (Peso < 0 || DistanciaFocal < 0 || Apertura < 0 || string.IsNullOrWhiteSpace(RelacionFocal))
            {
                throw new LogicaNegocioException("Peso, Distancia Focal, Apertura y Relacion Focal son obligatorios");
            }
        }

        public override void Update(Equipo obj)
        {
            base.Update(obj);
            if (obj is Telescopio telescopio)
            {
                Peso = telescopio.Peso;
                DistanciaFocal = telescopio.DistanciaFocal;
                Apertura = telescopio.Apertura;
                RelacionFocal = telescopio.RelacionFocal;
                Validar();
            }
            else
            {
                throw new LogicaNegocioException("El objeto a actualizar no es un telescopio");
            }
        }

        public override string GetNombre()
        {
            return "Telescopio";
        }
    }
}
