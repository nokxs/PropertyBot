using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes    {
        [JsonPropertyName("KAUF")]
        public string KAUF { get; set; } 

        [JsonPropertyName("MIETE_PACHT")]
        public string MIETEPACHT { get; set; } 
    }
}