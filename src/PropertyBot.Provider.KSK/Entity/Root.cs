using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Root    
    {
        [JsonIgnore]
        [JsonPropertyName("_links")]
        public Links Links { get; set; } 

        [JsonPropertyName("_embedded")]
        public Embedded Embedded { get; set; } 

        [JsonPropertyName("page_count")]
        public int PageCount { get; set; }

        [JsonIgnore]
        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }

        [JsonIgnore]
        [JsonPropertyName("total_items")]
        public int TotalItems { get; set; }

        [JsonIgnore]
        [JsonPropertyName("page")]
        public int Page { get; set; } 
    }
}