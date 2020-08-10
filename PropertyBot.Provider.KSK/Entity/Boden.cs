using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Boden    {
        [JsonPropertyName("attributes")]
        public Attributes10 Attributes { get; set; } 
    }
}