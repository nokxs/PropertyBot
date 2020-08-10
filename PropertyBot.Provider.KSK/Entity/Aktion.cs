using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Aktion    {
        [JsonPropertyName("attributes")]
        public Attributes19 Attributes { get; set; } 
    }
}