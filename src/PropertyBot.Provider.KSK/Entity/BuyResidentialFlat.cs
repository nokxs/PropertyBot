using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class BuyResidentialFlat    {
        [JsonPropertyName("object_type")]
        public string ObjectType { get; set; } 

        [JsonPropertyName("main_facts")]
        public List<MainFact> MainFacts { get; set; } 
    }
}