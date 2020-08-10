using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes18    {
        [JsonPropertyName("location")]
        public string Location { get; set; } 

        [JsonPropertyName("gruppe")]
        public string Gruppe { get; set; } 
    }
}