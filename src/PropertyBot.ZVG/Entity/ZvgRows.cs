using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.ZVG.Entity
{
    internal class ZvgRows
    {
        [JsonPropertyName("rows")]
        public IEnumerable<ZvgObject> Rows { get; set; } = Enumerable.Empty<ZvgObject>();
    }
}