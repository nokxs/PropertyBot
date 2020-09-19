using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Ausstattung    {
        [JsonPropertyName("heizungsart")]
        public Heizungsart Heizungsart { get; set; } 

        [JsonPropertyName("befeuerung")]
        public Befeuerung Befeuerung { get; set; } 

        [JsonPropertyName("ausstatt_kategorie")]
        public string AusstattKategorie { get; set; } 

        [JsonPropertyName("bad")]
        public Bad Bad { get; set; } 

        [JsonPropertyName("kueche")]
        public Kueche Kueche { get; set; } 

        [JsonPropertyName("boden")]
        public Boden Boden { get; set; } 

        [JsonPropertyName("stellplatzart")]
        public Stellplatzart Stellplatzart { get; set; } 

        [JsonPropertyName("gartennutzung")]
        public string Gartennutzung { get; set; } 

        [JsonPropertyName("kabel_sat_tv")]
        public string KabelSatTv { get; set; } 

        [JsonPropertyName("unterkellert")]
        public Unterkellert Unterkellert { get; set; } 

        [JsonPropertyName("abstellraum")]
        public string Abstellraum { get; set; } 

        [JsonPropertyName("bauweise")]
        public Bauweise Bauweise { get; set; } 

        [JsonPropertyName("gaestewc")]
        public string Gaestewc { get; set; } 

        [JsonPropertyName("fahrstuhl")]
        public Fahrstuhl Fahrstuhl { get; set; } 

        [JsonPropertyName("breitband_zugang")]
        public BreitbandZugang BreitbandZugang { get; set; } 

        [JsonPropertyName("seniorengerecht")]
        public string Seniorengerecht { get; set; } 
    }
}