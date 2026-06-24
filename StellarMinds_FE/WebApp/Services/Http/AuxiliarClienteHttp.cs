using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WebApp.Services.Http
{
    public class AuxiliarClienteHttp(IHttpClientFactory _factory)
    {

        public HttpResponseMessage EnviarSolicitud(string relativeUrl, string verbo, object? body = null, string? token = null)
        {
            var client = _factory.CreateClient("Api");
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage resp = verbo.ToUpper() switch
            {
                "GET" => client.GetAsync(relativeUrl).GetAwaiter().GetResult(),
                "POST" => client.PostAsync(relativeUrl, CreateJsonContent(body)).GetAwaiter().GetResult(),
                "PUT" => client.PutAsync(relativeUrl, CreateJsonContent(body)).GetAwaiter().GetResult(),
                "DELETE" => client.DeleteAsync(relativeUrl).GetAwaiter().GetResult(),
                _ => throw new ArgumentException("Verbo no soportado", nameof(verbo))
            };

            if (resp.IsSuccessStatusCode)
            {
                return resp;
            }

            string json = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine($"=== ERROR API ===\n{json}\n================");
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            //Error error = JsonSerializer.Deserialize<Error>(json, opts);
            //throw new Exception(error.Message);

            //COMENTAR ESE THROW Y DEJAR EL QUE LE SIGE
            //throw new Exception($"Status: {resp.StatusCode} - JSON: {json}");


            //using var doc = JsonDocument.Parse(json);
            //var root = doc.RootElement;
            //string? message = null;

            //message = doc.RootElement.GetProperty("error").GetProperty("message").GetString();
            //throw new Exception(message ?? "Error desconocido");

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            string? message = null;

            // tu error controlado: { "error": { "message": "..." } }
            if (root.TryGetProperty("error", out var errorObj) &&
                errorObj.TryGetProperty("message", out var msgProp))
            {
                message = msgProp.GetString();
            }
            // error de validación de ASP.NET: { "errors": { "campo": ["msg"] } }
            else if (root.TryGetProperty("errors", out var errorsObj))
            {
                var mensajes = new List<string>();
                foreach (var campo in errorsObj.EnumerateObject())
                    foreach (var msg in campo.Value.EnumerateArray())
                        mensajes.Add(msg.GetString() ?? "");
                message = string.Join(", ", mensajes);
            }
            // error genérico de ASP.NET: { "title": "..." }
            else if (root.TryGetProperty("title", out var title))
            {
                message = title.GetString();
            }

            throw new Exception(message ?? $"Error {resp.StatusCode}: {json}");

        }

        public string ObtenerBody(HttpResponseMessage respuesta)
        {
            return respuesta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public T? EnviarYDeserializar<T>(string relativeUrl, string verbo, object? body = null, string? token = null)
        {
            var resp = EnviarSolicitud(relativeUrl, verbo, body, token);
            var json = ObtenerBody(resp);
            //var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(json, opts);
        }

        private static HttpContent? CreateJsonContent(object? obj)
        {
            if (obj == null)
                return null;
            var json = JsonSerializer.Serialize(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
