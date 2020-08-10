using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Root    {
        [JsonPropertyName("_links")]
        [JsonIgnore]
        public Links Links { get; set; } 

        [JsonPropertyName("_embedded")]
        public Embedded Embedded { get; set; } 

        [JsonPropertyName("page_count")]
        public int PageCount { get; set; } 

        [JsonPropertyName("page_size")]
        public int PageSize { get; set; } 

        [JsonPropertyName("total_items")]
        public int TotalItems { get; set; } 

        [JsonPropertyName("page")]
        public int Page { get; set; } 
    }
}