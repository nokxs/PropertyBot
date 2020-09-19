using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Objektart    {
        [JsonPropertyName("wohnung")]
        public Wohnung Wohnung { get; set; } 
    }
}