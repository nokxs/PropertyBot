using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class UserDefinedAnyfield    {
        [JsonPropertyName("exclusiv_objekt")]
        public string ExclusivObjekt { get; set; } 
    }
}