using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Wohnung    {
        [JsonPropertyName("attributes")]
        public Attributes3 Attributes { get; set; } 
    }
}