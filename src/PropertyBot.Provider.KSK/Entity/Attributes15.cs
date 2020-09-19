using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes15    {
        [JsonPropertyName("art")]
        public string Art { get; set; } 

        [JsonPropertyName("speed")]
        public string Speed { get; set; } 
    }
}