using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Bad    {
        [JsonPropertyName("attributes")]
        public Attributes8 Attributes { get; set; } 
    }
}