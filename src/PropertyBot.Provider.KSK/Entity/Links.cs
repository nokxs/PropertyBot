using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Links    {
        [JsonPropertyName("self")]
        public Self Self { get; set; } 

        [JsonPropertyName("portal")]
        public Portal Portal { get; set; } 

        [JsonPropertyName("first")]
        public First First { get; set; } 

        [JsonPropertyName("last")]
        public Last Last { get; set; } 

        [JsonPropertyName("next")]
        public Next Next { get; set; } 
    }
}