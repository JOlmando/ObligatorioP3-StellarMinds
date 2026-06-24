using System.Text.Json;
using System.Text.Json.Serialization;

namespace StellarMinds.WebAPI.Model.IA;

public class ResponseIA
{
    [JsonPropertyName("candidates")]
    public List<Candidate>? Candidates { get; set; }

    public static T? Parsear<T>(string responseContent)
    {
        var response = JsonSerializer.Deserialize<ResponseIA>(responseContent);

        var texto = response?
            .Candidates?
            .FirstOrDefault()?
            .Content?
            .Parts?
            .FirstOrDefault()?
            .Text;

        if (string.IsNullOrWhiteSpace(texto))
            return default;

        Console.WriteLine(texto);

        texto = LimpiarRespuesta(texto);

        return JsonSerializer.Deserialize<T>(texto);
    }

    private static string LimpiarRespuesta(string texto)
    {
        return texto
            .Replace("```json", "", StringComparison.OrdinalIgnoreCase)
            .Replace("```", "", StringComparison.OrdinalIgnoreCase)
            .Trim();
    }

    // DTOs
    public class Candidate
    {
        [JsonPropertyName("content")]
        public Content? Content { get; set; }
    }

    public class Content
    {
        [JsonPropertyName("parts")]
        public List<Part>? Parts { get; set; }
    }

    public class Part
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
