using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Anhaenge    {
        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; } 

        [JsonPropertyName("format")]
        public string Format { get; set; } 

        [JsonPropertyName("@attributes")]
        public Attributes18 Attributes { get; set; } 

        [JsonPropertyName("anhangtitel")]
        public string Anhangtitel { get; set; } 

        [JsonPropertyName("md5")]
        public string Md5 { get; set; } 
    }
}