using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Flaechen
    {
        [JsonPropertyName("wohnflaeche")]
        public string Wohnflaeche { get; set; }
        
        [JsonPropertyName("grundstuecksflaeche")]
        public string Grundstuecksflaeche { get; set; }

        [JsonPropertyName("anzahl_zimmer")]
        public string AnzahlZimmer { get; set; } 

        [JsonPropertyName("anzahl_badezimmer")]
        public string AnzahlBadezimmer { get; set; } 

        [JsonPropertyName("anzahl_sep_wc")]
        public string AnzahlSepWc { get; set; } 

        [JsonPropertyName("anzahl_balkone")]
        public string AnzahlBalkone { get; set; } 

        [JsonPropertyName("anzahl_stellplaetze")]
        public string AnzahlStellplaetze { get; set; } 

        [JsonPropertyName("anzahl_schlafzimmer")]
        public string AnzahlSchlafzimmer { get; set; } 

        [JsonPropertyName("anzahl_terrassen")]
        public string AnzahlTerrassen { get; set; } 

        [JsonPropertyName("nutzflaeche")]
        public string Nutzflaeche { get; set; } 
    }
}