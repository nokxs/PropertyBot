using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Preise    {
        [JsonPropertyName("kaufpreis")]
        public string Kaufpreis { get; set; } 

        [JsonPropertyName("zzg_mehrwertsteuer")]
        public string ZzgMehrwertsteuer { get; set; } 

        [JsonPropertyName("provisionspflichtig")]
        public string Provisionspflichtig { get; set; } 

        [JsonPropertyName("aussen_courtage")]
        public string AussenCourtage { get; set; } 

        [JsonPropertyName("waehrung")]
        public Waehrung Waehrung { get; set; } 

        [JsonPropertyName("hausgeld")]
        public string Hausgeld { get; set; } 

        [JsonPropertyName("mieteinnahmen_ist")]
        public string MieteinnahmenIst { get; set; } 
    }
}