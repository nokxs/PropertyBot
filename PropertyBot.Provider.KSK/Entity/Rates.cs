using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Rates    {
        [JsonPropertyName("60350130")]
        public List<object> RateList { get; set; } 
    }
}