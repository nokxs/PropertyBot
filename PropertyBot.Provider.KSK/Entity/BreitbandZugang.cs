using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class BreitbandZugang    {
        [JsonPropertyName("attributes")]
        public Attributes15 Attributes { get; set; } 
    }
}