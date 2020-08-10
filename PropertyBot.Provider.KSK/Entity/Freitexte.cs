using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Freitexte    {
        [JsonPropertyName("objekttitel")]
        public string Objekttitel { get; set; } 

        [JsonPropertyName("ausstatt_beschr")]
        public string AusstattBeschr { get; set; } 

        [JsonPropertyName("objektbeschreibung")]
        public string Objektbeschreibung { get; set; } 

        [JsonPropertyName("lage")]
        public string Lage { get; set; } 

        [JsonPropertyName("sonstige_angaben")]
        public string SonstigeAngaben { get; set; } 
    }
}