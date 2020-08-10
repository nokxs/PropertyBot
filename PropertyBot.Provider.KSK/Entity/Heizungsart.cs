using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Heizungsart    {
        [JsonPropertyName("attributes")]
        public Attributes6 Attributes { get; set; } 
    }
}