using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Links2    {
        [JsonPropertyName("self")]
        public Self2 Self { get; set; } 
    }
}