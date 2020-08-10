using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Geo    {
        [JsonPropertyName("plz")]
        public string Plz { get; set; } 

        [JsonPropertyName("ort")]
        public string Ort { get; set; } 

        [JsonPropertyName("bundesland")]
        public string Bundesland { get; set; } 

        [JsonPropertyName("land")]
        public Land Land { get; set; } 

        [JsonPropertyName("anzahl_etagen")]
        public string AnzahlEtagen { get; set; } 

        [JsonPropertyName("regionaler_zusatz")]
        public string RegionalerZusatz { get; set; } 

        [JsonPropertyName("etage")]
        public string Etage { get; set; } 
    }
}