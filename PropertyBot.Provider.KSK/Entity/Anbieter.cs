using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Anbieter    {
        [JsonPropertyName("anbieternr")]
        public string Anbieternr { get; set; } 

        [JsonPropertyName("firma")]
        public string Firma { get; set; } 

        [JsonPropertyName("openimmo_anid")]
        public string OpenimmoAnid { get; set; } 
    }
}