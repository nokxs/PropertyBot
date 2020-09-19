using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes6    {
        [JsonPropertyName("OFEN")]
        public string OFEN { get; set; } 

        [JsonPropertyName("ETAGE")]
        public string ETAGE { get; set; } 

        [JsonPropertyName("ZENTRAL")]
        public string ZENTRAL { get; set; } 

        [JsonPropertyName("FERN")]
        public string FERN { get; set; } 

        [JsonPropertyName("FUSSBODEN")]
        public string FUSSBODEN { get; set; } 
    }
}