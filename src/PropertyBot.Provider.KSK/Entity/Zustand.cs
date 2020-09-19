using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Zustand    {
        [JsonPropertyName("attributes")]
        public Attributes17 Attributes { get; set; } 
    }
}