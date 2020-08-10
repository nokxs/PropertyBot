using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Image    {
        [JsonPropertyName("formats")]
        public Formats Formats { get; set; } 

        [JsonPropertyName("title")]
        public string Title { get; set; } 

        [JsonPropertyName("md5")]
        public string Md5 { get; set; } 

        [JsonPropertyName("group")]
        public string Group { get; set; } 
    }
}