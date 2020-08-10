using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes2    {
        [JsonPropertyName("WOHNEN")]
        public string WOHNEN { get; set; } 

        [JsonPropertyName("GEWERBE")]
        public string GEWERBE { get; set; } 
    }
}