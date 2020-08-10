using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes9    {
        [JsonPropertyName("EBK")]
        public string EBK { get; set; } 

        [JsonPropertyName("OFFEN")]
        public string OFFEN { get; set; } 

        [JsonPropertyName("PANTRY")]
        public string PANTRY { get; set; } 
    }
}