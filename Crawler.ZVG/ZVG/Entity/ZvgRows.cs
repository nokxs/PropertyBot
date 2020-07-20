using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Crawler.ZVG.ZVG.Entity
{
    public class ZvgRows
    {
        [JsonPropertyName("rows")]
        public IEnumerable<ZvgObject> Rows { get; set; }
    }
}