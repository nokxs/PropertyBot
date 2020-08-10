using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Waehrung    {
        [JsonPropertyName("attributes")]
        public Attributes5 Attributes { get; set; } 
    }
}