using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Nutzungsart    {
        [JsonPropertyName("attributes")]
        public Attributes2 Attributes { get; set; } 
    }
}