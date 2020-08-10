using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class MainFact    {
        [JsonPropertyName("label")]
        public string Label { get; set; } 

        [JsonPropertyName("value")]
        public string Value { get; set; } 
    }
}