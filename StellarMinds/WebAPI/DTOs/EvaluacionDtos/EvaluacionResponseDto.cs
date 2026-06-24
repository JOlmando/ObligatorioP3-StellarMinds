namespace StellarMinds.WebAPI.DTOs.EvaluacionDtos
{
    // DTOs/EvaluacionResponseDto.cs
    public class EvaluacionResponseDto
    {
        public string Indicador { get; set; }  // "IDEAL", "ADECUADO", "NO RECOMENDABLE"
        public string Detalle { get; set; }
    }
}
