using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Stellplatzart    {
        [JsonPropertyName("attributes")]
        public Attributes11 Attributes { get; set; } 
    }
}