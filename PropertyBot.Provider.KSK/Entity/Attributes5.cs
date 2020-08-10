using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes5    {
        [JsonPropertyName("iso_waehrung")]
        public string IsoWaehrung { get; set; } 
    }
}