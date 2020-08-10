using System.Text.Json.Serialization;

namespace PropertyBot.Provider.ZVG.Entity
{
    internal class ZvgData
    {
        [JsonPropertyName("0")]
        public string ImageTag { get; set; }

        [JsonPropertyName("1")]
        public string DescriptionTag { get; set; }

        [JsonPropertyName("2")]
        public string AuctionDetails { get; set; }

        [JsonPropertyName("3")]
        public string AddDate { get; set; }
    }
}