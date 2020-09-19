using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Objektkategorie    {
        [JsonPropertyName("vermarktungsart")]
        public Vermarktungsart Vermarktungsart { get; set; } 

        [JsonPropertyName("nutzungsart")]
        public Nutzungsart Nutzungsart { get; set; } 

        [JsonPropertyName("objektart")]
        public Objektart Objektart { get; set; } 
    }
}