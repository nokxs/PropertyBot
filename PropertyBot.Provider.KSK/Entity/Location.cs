using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Location    {
        [JsonPropertyName("lon")]
        public string Lon { get; set; } 

        [JsonPropertyName("lat")]
        public string Lat { get; set; } 
    }
}