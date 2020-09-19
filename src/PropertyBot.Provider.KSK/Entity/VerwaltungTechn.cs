using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class VerwaltungTechn    {
        [JsonPropertyName("objektnr_intern")]
        public string ObjektnrIntern { get; set; } 

        [JsonPropertyName("objektnr_extern")]
        public string ObjektnrExtern { get; set; } 

        [JsonPropertyName("aktion")]
        public Aktion Aktion { get; set; } 

        [JsonPropertyName("openimmo_obid")]
        public string OpenimmoObid { get; set; } 

        [JsonPropertyName("stand_vom")]
        public string StandVom { get; set; } 

        [JsonPropertyName("sprache")]
        public string Sprache { get; set; } 
    }
}