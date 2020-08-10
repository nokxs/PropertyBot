using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Estate    {
        [JsonPropertyName("objektkategorie")]
        public Objektkategorie Objektkategorie { get; set; } 

        [JsonPropertyName("geo")]
        public Geo Geo { get; set; }

        [JsonIgnore]
        [JsonPropertyName("kontaktperson")]
        public Kontaktperson Kontaktperson { get; set; } 

        [JsonPropertyName("preise")]
        public Preise Preise { get; set; }

        [JsonIgnore]
        [JsonPropertyName("versteigerung")]
        public List<object> Versteigerung { get; set; } 

        [JsonPropertyName("flaechen")]
        public Flaechen Flaechen { get; set; }

        [JsonIgnore]
        [JsonPropertyName("ausstattung")]
        public Ausstattung Ausstattung { get; set; } 

        [JsonPropertyName("zustand_angaben")]
        public ZustandAngaben ZustandAngaben { get; set; } 

        [JsonPropertyName("freitexte")]
        public Freitexte Freitexte { get; set; }

        [JsonIgnore]
        [JsonPropertyName("anhaenge")]
        public List<Anhaenge> Anhaenge { get; set; }

        [JsonIgnore]
        [JsonPropertyName("verwaltung_objekt")]
        public VerwaltungObjekt VerwaltungObjekt { get; set; }

        [JsonIgnore]
        [JsonPropertyName("verwaltung_techn")]
        public VerwaltungTechn VerwaltungTechn { get; set; } 

        [JsonPropertyName("anbieter")]
        public Anbieter Anbieter { get; set; } 

        [JsonPropertyName("sip")]
        public Sip Sip { get; set; }

        [JsonIgnore]
        [JsonPropertyName("_id")]
        public string IdUnderscore { get; set; } 

        [JsonPropertyName("id")]
        public string Id { get; set; } 

        [JsonIgnore]
        [JsonPropertyName("_links")]
        public Links2 Links { get; set; } 
    }
}