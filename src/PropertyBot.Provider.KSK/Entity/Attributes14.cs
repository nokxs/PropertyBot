using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes14    {
        [JsonPropertyName("PERSONEN")]
        public string PERSONEN { get; set; } 

        [JsonPropertyName("LASTEN")]
        public string LASTEN { get; set; } 
    }
}