using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Energiepass    {
        [JsonPropertyName("epart")]
        public string Epart { get; set; } 

        [JsonPropertyName("gueltig_bis")]
        public string GueltigBis { get; set; } 

        [JsonPropertyName("energieverbrauchkennwert")]
        public string Energieverbrauchkennwert { get; set; } 

        [JsonPropertyName("mitwarmwasser")]
        public string Mitwarmwasser { get; set; } 

        [JsonPropertyName("primaerenergietraeger")]
        public string Primaerenergietraeger { get; set; } 

        [JsonPropertyName("wertklasse")]
        public string Wertklasse { get; set; } 

        [JsonPropertyName("baujahr")]
        public string Baujahr { get; set; } 

        [JsonPropertyName("ausstelldatum")]
        public string Ausstelldatum { get; set; } 

        [JsonPropertyName("jahrgang")]
        public string Jahrgang { get; set; } 

        [JsonPropertyName("gebaeudeart")]
        public string Gebaeudeart { get; set; } 

        [JsonPropertyName("endenergiebedarf")]
        public string Endenergiebedarf { get; set; } 
    }
}