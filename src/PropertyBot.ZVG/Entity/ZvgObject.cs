using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.ZVG.Entity
{
    internal class ZvgObject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("data")]
        public IEnumerable<string> Data { get; set; }
    }
}
