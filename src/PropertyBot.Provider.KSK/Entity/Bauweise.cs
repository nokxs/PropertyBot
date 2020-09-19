using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Bauweise    {
        [JsonPropertyName("attributes")]
        public Attributes13 Attributes { get; set; } 
    }
}