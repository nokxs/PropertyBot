using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Kueche    {
        [JsonPropertyName("attributes")]
        public Attributes9 Attributes { get; set; } 
    }
}