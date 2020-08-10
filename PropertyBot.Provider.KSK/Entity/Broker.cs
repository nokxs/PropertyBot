using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Broker    {
        [JsonPropertyName("id")]
        public int Id { get; set; } 

        [JsonPropertyName("disclaimer_config_is_active")]
        public bool DisclaimerConfigIsActive { get; set; } 
    }
}