using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Befeuerung    {
        [JsonPropertyName("attributes")]
        public Attributes7 Attributes { get; set; } 
    }
}