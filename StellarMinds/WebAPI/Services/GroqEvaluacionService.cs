using StellarMinds.WebAPI.DTOs.EvaluacionDtos;
using System.Text;
using System.Text.Json;


namespace StellarMinds.WebAPI.Services
{
    // Services/GroqEvaluacionService.cs
    public class GroqEvaluacionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GroqEvaluacionService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["Groq:ApiKey"]
                ?? throw new InvalidOperationException("Falta Groq:ApiKey en configuración");
        }

        public async Task<EvaluacionResponseDto> EvaluarEquipoAsync(EvaluacionRequestDto request)
        {
            var body = new
            {
                model = "llama-3.3-70b-versatile",
                temperature = 0.2,
                max_tokens = 200,
                messages = new[]
                {
                new
                {
                    role = "system",
                    content = @"Eres experto en fisica, cosmologia, astronomía y astrofotografia, debes validar una observacion con los equipos que te paso y si son aptos para dicha observacion.
                                si el equipo es adecuado para observar
                                o fotografiar dichos objetos celestes. Por ejemplo, no debería intentar fotografiar una galaxia pequeña con un telescopio de distancia focal muy corta sin una cámara de alta resolución. 
                                Si el préstamo incluye una cámara el sistema asumirá que el tipo de observación es astrofotografía.
                                Los datos para enviarle al servicio de IA serán los siguientes:
                                Telescopio: Apertura (mm), Distancia Focal (mm) y Relación focal (f/x).
                                Cámara: Tipo de Sensor, Resolución y Tamaño de píxel (µm)
                                Ocular: Diámetro (mm) y campo visual (grados)
                                Objeto celeste: Nombre y tipo.
                                Camara u ocular, es uno u otro.
                                Indicador puede ser: IDEAL, ADECUADO o NO RECOMENDABLE.
                                Un breve detalle del motivo solo en caso de que el indicador no sea IDEAL (de no más de 300 caracteres)
                                Responde SOLO con JSON válido así:
                                {
                                    indicador: "", 
                                    detalle: ""
                                }
                                "
                },
                new
                {
                    role = "user",
                    content = BuildPrompt(request)
                }
            }
            };

            var jsonBody = JsonSerializer.Serialize(body);

            var httpContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://api.groq.com/openai/v1/chat/completions");

            httpRequest.Headers.Add("Authorization", $"Bearer {_apiKey}");

            httpRequest.Content = httpContent;

            var response = await _httpClient.SendAsync(httpRequest);

            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseJson);
            var modelText = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString() ?? throw new Exception("Respuesta vacía de Groq");

            var cleanText = modelText
                .Replace("```json", "")
                .Replace("```", "")
                .Trim();

            var resultado = JsonSerializer.Deserialize<EvaluacionResponseDto>(
                cleanText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            ) ?? throw new Exception("No se pudo parsear la respuesta de Groq");

            return resultado;
        }

        private string BuildPrompt(EvaluacionRequestDto request)
        {
            var equipo = new Dictionary<string, object>();

            equipo["telescopio"] = new
            {
                apertura_mm = request.Telescopio.AperturaMm,
                focal_mm = request.Telescopio.FocalMm,
                relacion_focal = request.Telescopio.RelacionFocal
            };

            if (request.Camara != null)
                equipo["camara"] = new
                {
                    sensor = request.Camara.Sensor,
                    resolucion_px = request.Camara.ResolucionPx,
                    pixel_size_um = request.Camara.TamanioPixel
                };

            if (request.Ocular != null)
                equipo["ocular"] = new
                {
                    AnguloVision = request.Ocular.AnguloVision,
                    Diametro = request.Ocular.Diametro
                };

            equipo["objeto_celeste"] = new
            {
                nombre = request.ObjetoCeleste.Nombre,
                tipo = request.ObjetoCeleste.Tipo
            };

            return JsonSerializer.Serialize(equipo, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
