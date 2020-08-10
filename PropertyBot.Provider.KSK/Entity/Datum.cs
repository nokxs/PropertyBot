using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Datum    {
        [JsonPropertyName("original")]
        public string Original { get; set; } 

        [JsonPropertyName("xs")]
        public string Xs { get; set; } 

        [JsonPropertyName("s")]
        public string S { get; set; } 

        [JsonPropertyName("m")]
        public string M { get; set; } 

        [JsonPropertyName("xl")]
        public string Xl { get; set; } 
    }
}