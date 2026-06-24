using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class ObjetoCeleste
    {
        public int Id { get; set; }
        public VOName Nombre { get; set; }
        public double MagnitudAparente { get; set; }
        public string TipoCeleste { get; set; } // Planeta, Galaxia, Nebulosa, Estrella, etc. Posible VOTipoCeleste con un enum para los tipos predefinidos.

        private ObjetoCeleste() { }

        public ObjetoCeleste(VOName nombre, double magnitudAparente, string tipoCeleste)
        {
            Nombre = nombre;
            MagnitudAparente = magnitudAparente;
            TipoCeleste = tipoCeleste;
        }

    }


}