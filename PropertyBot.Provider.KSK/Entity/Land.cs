using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Land    {
        [JsonPropertyName("attributes")]
        public Attributes4 Attributes { get; set; } 
    }
}