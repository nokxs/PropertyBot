using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Fahrstuhl    {
        [JsonPropertyName("attributes")]
        public Attributes14 Attributes { get; set; } 
    }
}