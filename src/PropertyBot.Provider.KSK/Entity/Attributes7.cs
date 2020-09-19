using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Attributes7    {
        [JsonPropertyName("OEL")]
        public string OEL { get; set; } 

        [JsonPropertyName("GAS")]
        public string GAS { get; set; } 

        [JsonPropertyName("ELEKTRO")]
        public string ELEKTRO { get; set; } 

        [JsonPropertyName("ALTERNATIV")]
        public string ALTERNATIV { get; set; } 

        [JsonPropertyName("SOLAR")]
        public string SOLAR { get; set; } 

        [JsonPropertyName("ERDWAERME")]
        public string ERDWAERME { get; set; } 

        [JsonPropertyName("LUFTWP")]
        public string LUFTWP { get; set; } 

        [JsonPropertyName("FERN")]
        public string FERN { get; set; } 

        [JsonPropertyName("BLOCK")]
        public string BLOCK { get; set; } 

        [JsonPropertyName("WASSER-ELEKTRO")]
        public string WASSERELEKTRO { get; set; } 

        [JsonPropertyName("PELLET")]
        public string PELLET { get; set; } 

        [JsonPropertyName("KOHLE")]
        public string KOHLE { get; set; } 

        [JsonPropertyName("HOLZ")]
        public string HOLZ { get; set; } 

        [JsonPropertyName("FLUESSIGGAS")]
        public string FLUESSIGGAS { get; set; } 
    }
}