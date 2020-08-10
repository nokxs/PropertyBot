using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Estate    {
        [JsonPropertyName("objektkategorie")]
        public Objektkategorie Objektkategorie { get; set; } 

        [JsonPropertyName("geo")]
        public Geo Geo { get; set; } 

        [JsonPropertyName("kontaktperson")]
        public Kontaktperson Kontaktperson { get; set; } 

        [JsonPropertyName("preise")]
        public Preise Preise { get; set; } 

        [JsonPropertyName("versteigerung")]
        public List<object> Versteigerung { get; set; } 

        [JsonPropertyName("flaechen")]
        public Flaechen Flaechen { get; set; } 

        [JsonPropertyName("ausstattung")]
        public Ausstattung Ausstattung { get; set; } 

        [JsonPropertyName("zustand_angaben")]
        public ZustandAngaben ZustandAngaben { get; set; } 

        [JsonPropertyName("freitexte")]
        public Freitexte Freitexte { get; set; } 

        [JsonPropertyName("anhaenge")]
        public List<Anhaenge> Anhaenge { get; set; } 

        [JsonPropertyName("verwaltung_objekt")]
        public VerwaltungObjekt VerwaltungObjekt { get; set; } 

        [JsonPropertyName("verwaltung_techn")]
        public VerwaltungTechn VerwaltungTechn { get; set; } 

        [JsonPropertyName("anbieter")]
        public Anbieter Anbieter { get; set; } 

        [JsonPropertyName("sip")]
        public Sip Sip { get; set; } 

        [JsonPropertyName("_id")]
        public string IdUnderscore { get; set; } 

        [JsonPropertyName("id")]
        public string Id { get; set; } 

        [JsonPropertyName("_links")]
        public Links2 Links { get; set; } 
    }
}