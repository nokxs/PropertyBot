using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Verkaufstatus    {
        [JsonPropertyName("attributes")]
        public Attributes16 Attributes { get; set; } 
    }
}