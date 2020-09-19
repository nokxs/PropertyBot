using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes10    {
        [JsonPropertyName("FLIESEN")]
        public string FLIESEN { get; set; } 

        [JsonPropertyName("STEIN")]
        public string STEIN { get; set; } 

        [JsonPropertyName("TEPPICH")]
        public string TEPPICH { get; set; } 

        [JsonPropertyName("PARKETT")]
        public string PARKETT { get; set; } 

        [JsonPropertyName("FERTIGPARKETT")]
        public string FERTIGPARKETT { get; set; } 

        [JsonPropertyName("LAMINAT")]
        public string LAMINAT { get; set; } 

        [JsonPropertyName("DIELEN")]
        public string DIELEN { get; set; } 

        [JsonPropertyName("KUNSTSTOFF")]
        public string KUNSTSTOFF { get; set; } 

        [JsonPropertyName("ESTRICH")]
        public string ESTRICH { get; set; } 

        [JsonPropertyName("DOPPELBODEN")]
        public string DOPPELBODEN { get; set; } 

        [JsonPropertyName("LINOLEUM")]
        public string LINOLEUM { get; set; } 

        [JsonPropertyName("MARMOR")]
        public string MARMOR { get; set; } 

        [JsonPropertyName("TERRAKOTTA")]
        public string TERRAKOTTA { get; set; } 

        [JsonPropertyName("GRANIT")]
        public string GRANIT { get; set; } 
    }
}