using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes11    {
        [JsonPropertyName("GARAGE")]
        public string GARAGE { get; set; } 

        [JsonPropertyName("TIEFGARAGE")]
        public string TIEFGARAGE { get; set; } 

        [JsonPropertyName("CARPORT")]
        public string CARPORT { get; set; } 

        [JsonPropertyName("FREIPLATZ")]
        public string FREIPLATZ { get; set; } 

        [JsonPropertyName("PARKHAUS")]
        public string PARKHAUS { get; set; } 

        [JsonPropertyName("DUPLEX")]
        public string DUPLEX { get; set; } 
    }
}