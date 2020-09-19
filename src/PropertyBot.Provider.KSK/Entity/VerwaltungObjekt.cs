using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class VerwaltungObjekt    {
        [JsonPropertyName("objektadresse_freigeben")]
        public string ObjektadresseFreigeben { get; set; } 

        [JsonPropertyName("verfuegbar_ab")]
        public string VerfuegbarAb { get; set; }
        
        [JsonIgnore]
        [JsonPropertyName("user_defined_anyfield")]
        public UserDefinedAnyfield UserDefinedAnyfield { get; set; } 

        [JsonPropertyName("vermietet")]
        public string Vermietet { get; set; } 

        [JsonPropertyName("abdatum")]
        public string Abdatum { get; set; } 

        [JsonPropertyName("haustiere")]
        public string Haustiere { get; set; } 
    }
}