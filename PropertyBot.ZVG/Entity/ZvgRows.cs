using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Crawler.Provider.ZVG.Entity
{
    internal class ZvgRows
    {
        [JsonPropertyName("rows")]
        public IEnumerable<ZvgObject> Rows { get; set; }
    }
}