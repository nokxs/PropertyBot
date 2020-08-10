using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Embedded    {
        [JsonPropertyName("estate")]
        public List<Estate> Estate { get; set; } 
    }
}