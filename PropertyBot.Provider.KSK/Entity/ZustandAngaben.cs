using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class ZustandAngaben    {
        [JsonPropertyName("baujahr")]
        public string Baujahr { get; set; } 

        [JsonPropertyName("energiepass")]
        public Energiepass Energiepass { get; set; } 

        [JsonPropertyName("verkaufstatus")]
        public Verkaufstatus Verkaufstatus { get; set; } 

        [JsonPropertyName("letztemodernisierung")]
        public string Letztemodernisierung { get; set; } 

        [JsonPropertyName("zustand")]
        public Zustand Zustand { get; set; } 
    }
}