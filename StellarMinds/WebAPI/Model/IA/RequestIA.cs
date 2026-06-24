using System.Text.Json.Serialization;

namespace StellarMinds.WebAPI.Model.IA;

public static class RequestIA
{
    public static Root Crear(string prompt)
    {
        return new Root
        {
            Contents =
            [
                new Content
                {
                    Parts =
                    [
                        new Part
                        {
                            Text = prompt
                        }
                    ]
                }
            ]
        };
    }

    public class Root
    {
        [JsonPropertyName("contents")]
        public List<Content> Contents { get; set; } = [];
    }

    public class Content
    {
        [JsonPropertyName("parts")]
        public List<Part> Parts { get; set; } = [];
    }

    public class Part
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
    }
}
