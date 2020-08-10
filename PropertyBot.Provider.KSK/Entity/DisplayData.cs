using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class DisplayData    {
        [JsonPropertyName("buy_residential_flat")]
        public BuyResidentialFlat BuyResidentialFlat { get; set; } 

        [JsonPropertyName("specials")]
        public List<string> Specials { get; set; } 
    }
}