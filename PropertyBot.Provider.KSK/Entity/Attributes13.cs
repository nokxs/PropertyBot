using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes13    {
        [JsonPropertyName("MASSIV")]
        public string MASSIV { get; set; } 

        [JsonPropertyName("FERTIGTEILE")]
        public string FERTIGTEILE { get; set; } 

        [JsonPropertyName("HOLZ")]
        public string HOLZ { get; set; } 
    }
}