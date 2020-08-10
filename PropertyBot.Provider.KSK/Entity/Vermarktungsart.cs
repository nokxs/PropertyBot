using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Vermarktungsart    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; } 
    }
}