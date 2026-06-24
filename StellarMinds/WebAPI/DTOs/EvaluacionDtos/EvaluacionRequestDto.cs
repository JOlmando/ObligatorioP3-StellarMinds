namespace StellarMinds.WebAPI.DTOs.EvaluacionDtos
{
    public class EvaluacionRequestDto(TelescopioEvalDto Telescopio, CamaraEvalDto? Camara, OcularEvalDto? Ocular, ObjetoCelesteEvalDto ObjetoCeleste)
    {
        public TelescopioEvalDto Telescopio { get; set; } = Telescopio;
        public CamaraEvalDto? Camara { get; set; } = Camara;
        public OcularEvalDto? Ocular { get; set; } = Ocular;
        public ObjetoCelesteEvalDto ObjetoCeleste { get; set; } = ObjetoCeleste;
    }

    public class TelescopioEvalDto(int? AperturaMm, int? FocalMm, string? RelacionFocal)
    {
        public int? AperturaMm { get; set; } = AperturaMm;
        public int? FocalMm { get; set; } = FocalMm;
        public string? RelacionFocal { get; set; } = RelacionFocal;

    }

    public class CamaraEvalDto(int? Sensor, int? ResolucionPx, int? TamanioPixel)
    {
        public int? Sensor { get; set; } = Sensor;
        public int? ResolucionPx { get; set; } = ResolucionPx;
        public int? TamanioPixel { get; set; } = TamanioPixel;
    }

    public class OcularEvalDto(int? AnguloVision, int? Diametro)
    {
        public int? AnguloVision { get; set; } = AnguloVision;
        public int? Diametro { get; set; } = Diametro;
    }

    public class ObjetoCelesteEvalDto(string Nombre, string Tipo)
    {
        public string Nombre { get; set; } = Nombre;
        public string Tipo { get; set; } = Tipo;
    }

}
