using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Ocular : Equipo
    {
        public int? Diametro { get; set; }
        public int? AnguloVision { get; set; }
        private Ocular() { }

        public Ocular(VOMarca marca,
                      VOModelo modelo,
                      VOCantidadDisponible cantidadDisponible,
                      int? diametro,
                      int? anguloVision) : base(marca, modelo, cantidadDisponible)
        {
            Diametro = diametro;
            AnguloVision = anguloVision;
            Validar();
        }

        public override void Validar()
        {
            base.Validar();
            if (Diametro < 0 || AnguloVision < 0)
            {
                throw new LogicaNegocioException("Diametro y Angulo de Vision son obligatorios");
            }
        }
        public override void Update(Equipo obj)
        {
            base.Update(obj);
            if (obj is Ocular ocular)
            {
                Diametro = ocular.Diametro;
                AnguloVision = ocular.AnguloVision;
                Validar();
            }
            else
            {
                throw new LogicaNegocioException("El objeto a actualizar no es un ocular");
            }
        }
        public override string GetNombre()
        {
            return "Ocular";
        }
    }
}
