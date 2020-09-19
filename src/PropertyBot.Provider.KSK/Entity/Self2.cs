using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Self2    {
        [JsonPropertyName("href")]
        public string Href { get; set; } 
    }
}