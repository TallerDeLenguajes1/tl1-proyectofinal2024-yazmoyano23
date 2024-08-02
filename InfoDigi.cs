// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
using System.Text.Json.Serialization;

namespace InfoDigi
{
    public class Digimon
    {
        [JsonPropertyName("name")]
        public string? name { get; set; }

        [JsonPropertyName("img")]
        public string? img { get; set; }

        [JsonPropertyName("level")]
        public string? level { get; set; }
    }  

    
}
