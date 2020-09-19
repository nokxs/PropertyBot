using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Next    {
        [JsonPropertyName("href")]
        public string Href { get; set; } 
    }
}