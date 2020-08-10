using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes8    {
        [JsonPropertyName("DUSCHE")]
        public string DUSCHE { get; set; } 

        [JsonPropertyName("WANNE")]
        public string WANNE { get; set; } 

        [JsonPropertyName("FENSTER")]
        public string FENSTER { get; set; } 

        [JsonPropertyName("BIDET")]
        public string BIDET { get; set; } 

        [JsonPropertyName("PISSOIR")]
        public string PISSOIR { get; set; } 
    }
}