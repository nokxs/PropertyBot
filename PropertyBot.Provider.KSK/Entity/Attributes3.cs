using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes3    {
        [JsonPropertyName("wohnungtyp")]
        public string Wohnungtyp { get; set; } 
    }
}