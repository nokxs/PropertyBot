using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Unterkellert    {
        [JsonPropertyName("attributes")]
        public Attributes12 Attributes { get; set; } 
    }
}