using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Generated usind https://json2csharp.com

namespace PropertyBot.Provider.KSK.Entity
{
    public class Alter
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Anbieter
    {
        [JsonPropertyName("anbieternr")]
        public string Anbieternr { get; set; }

        [JsonPropertyName("firma")]
        public string Firma { get; set; }

        [JsonPropertyName("openimmo_anid")]
        public string OpenimmoAnid { get; set; }
    }

    public class Anhaenge
    {
        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }

        [JsonPropertyName("md5")]
        public string Md5 { get; set; }

        [JsonPropertyName("@attributes")]
        public Attributes Attributes { get; set; }

        [JsonPropertyName("anhangtitel")]
        public string Anhangtitel { get; set; }

        [JsonPropertyName("format")]
        public string Format { get; set; }
    }

    public class Attributes
    {
        [JsonPropertyName("KAUF")]
        public bool KAUF { get; set; }

        [JsonPropertyName("WOHNEN")]
        public bool WOHNEN { get; set; }

        [JsonPropertyName("GEWERBE")]
        public bool GEWERBE { get; set; }

        [JsonPropertyName("grundst_typ")]
        public string GrundstTyp { get; set; }

        [JsonPropertyName("iso_land")]
        public string IsoLand { get; set; }

        [JsonPropertyName("iso_waehrung")]
        public string IsoWaehrung { get; set; }

        [JsonPropertyName("alter_attr")]
        public string AlterAttr { get; set; }

        [JsonPropertyName("erschl_attr")]
        public string ErschlAttr { get; set; }
    }

    public class Attributes8
    {
        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("gruppe")]
        public string Gruppe { get; set; }
    }

    public class Broker
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }

    public class BuyBusinessOthers
    {
        [JsonPropertyName("object_type")]
        public string ObjectType { get; set; }

        [JsonPropertyName("main_facts")]
        public List<MainFact> MainFacts { get; set; }
    }

    public class BuyBusinessProperty
    {
        [JsonPropertyName("object_type")]
        public string ObjectType { get; set; }

        [JsonPropertyName("main_facts")]
        public List<MainFact> MainFacts { get; set; }
    }

    public class BuyResidentialProperty
    {
        [JsonPropertyName("object_type")]
        public string ObjectType { get; set; }

        [JsonPropertyName("main_facts")]
        public List<MainFact> MainFacts { get; set; }
    }

    public class Contact
    {
        [JsonPropertyName("phone_required")]
        public bool PhoneRequired { get; set; }

        [JsonPropertyName("address_required")]
        public bool AddressRequired { get; set; }

        [JsonPropertyName("consumer_information")]
        public string ConsumerInformation { get; set; }

        [JsonPropertyName("privacy")]
        public string Privacy { get; set; }
    }

    public class Datum
    {
        [JsonPropertyName("original")]
        public string Original { get; set; }

        [JsonPropertyName("xs")]
        public string Xs { get; set; }

        [JsonPropertyName("s")]
        public string S { get; set; }

        [JsonPropertyName("m")]
        public string M { get; set; }

        [JsonPropertyName("xl")]
        public string Xl { get; set; }
    }

    public class DisplayData
    {
        [JsonPropertyName("buy_residential_property")]
        public BuyResidentialProperty BuyResidentialProperty { get; set; }

        [JsonPropertyName("buy_business_property")]
        public BuyBusinessProperty BuyBusinessProperty { get; set; }

        [JsonPropertyName("buy_business_others")]
        public BuyBusinessOthers BuyBusinessOthers { get; set; }

        [JsonPropertyName("specials")]
        public List<object> Specials { get; set; }
    }

    public class Embedded
    {
        [JsonPropertyName("estate")]
        public List<Estate> Estate { get; set; }
    }

    public class Erschliessung
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Estate
    {
        [JsonPropertyName("objektkategorie")]
        public Objektkategorie Objektkategorie { get; set; }

        [JsonPropertyName("geo")]
        public Geo Geo { get; set; }

        [JsonPropertyName("kontaktperson")]
        public Kontaktperson Kontaktperson { get; set; }

        [JsonPropertyName("preise")]
        public Preise Preise { get; set; }

        [JsonPropertyName("flaechen")]
        public Flaechen Flaechen { get; set; }

        [JsonPropertyName("ausstattung")]
        public List<object> Ausstattung { get; set; }

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

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class Flaechen
    {
        [JsonPropertyName("grundstuecksflaeche")]
        public int Grundstuecksflaeche { get; set; }
    }

    public class Formats
    {
        [JsonPropertyName("original")]
        public string Original { get; set; }

        [JsonPropertyName("xs")]
        public string Xs { get; set; }

        [JsonPropertyName("s")]
        public string S { get; set; }

        [JsonPropertyName("m")]
        public string M { get; set; }

        [JsonPropertyName("xl")]
        public string Xl { get; set; }
    }

    public class Freitexte
    {
        [JsonPropertyName("objekttitel")]
        public string Objekttitel { get; set; }

        [JsonPropertyName("lage")]
        public string Lage { get; set; }

        [JsonPropertyName("ausstatt_beschr")]
        public string AusstattBeschr { get; set; }

        [JsonPropertyName("objektbeschreibung")]
        public string Objektbeschreibung { get; set; }

        [JsonPropertyName("sonstige_angaben")]
        public string SonstigeAngaben { get; set; }
    }

    public class Geo
    {
        [JsonPropertyName("plz")]
        public string Plz { get; set; }

        [JsonPropertyName("ort")]
        public string Ort { get; set; }

        [JsonPropertyName("bundesland")]
        public string Bundesland { get; set; }

        [JsonPropertyName("regionaler_zusatz")]
        public string RegionalerZusatz { get; set; }

        [JsonPropertyName("land")]
        public Land Land { get; set; }
    }

    public class Grundstueck
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Image
    {
        [JsonPropertyName("formats")]
        public Formats Formats { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("md5")]
        public string Md5 { get; set; }

        [JsonPropertyName("group")]
        public string Group { get; set; }
    }

    public class IsShown
    {
        [JsonPropertyName("60050101")]
        public bool _60050101 { get; set; }
    }

    public class Kontaktperson
    {
        [JsonPropertyName("email_feedback")]
        public string EmailFeedback { get; set; }
    }

    public class Land
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }

    public class MainFact
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Nutzungsart
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Objektart
    {
        [JsonPropertyName("grundstueck")]
        public Grundstueck Grundstueck { get; set; }

        [JsonPropertyName("objektart_zusatz")]
        public string ObjektartZusatz { get; set; }
    }

    public class Objektkategorie
    {
        [JsonPropertyName("vermarktungsart")]
        public Vermarktungsart Vermarktungsart { get; set; }

        [JsonPropertyName("nutzungsart")]
        public Nutzungsart Nutzungsart { get; set; }

        [JsonPropertyName("objektart")]
        public Objektart Objektart { get; set; }
    }

    public class Preise
    {
        [JsonPropertyName("kaufpreis")]
        public int Kaufpreis { get; set; }

        [JsonPropertyName("provisionspflichtig")]
        public bool Provisionspflichtig { get; set; }

        [JsonPropertyName("aussen_courtage")]
        public string AussenCourtage { get; set; }

        [JsonPropertyName("waehrung")]
        public Waehrung Waehrung { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonPropertyName("total_items")]
        public int TotalItems { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }

        [JsonPropertyName("page_count")]
        public int PageCount { get; set; }
    }

    public class Sip
    {
        [JsonPropertyName("imprint_is_active")]
        public bool ImprintIsActive { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("modified")]
        public DateTime Modified { get; set; }

        [JsonPropertyName("owner_blz")]
        public int OwnerBlz { get; set; }

        [JsonPropertyName("broker")]
        public Broker Broker { get; set; }

        [JsonPropertyName("is_shown")]
        public IsShown IsShown { get; set; }

        [JsonPropertyName("marketing_usage_object_types")]
        public List<string> MarketingUsageObjectTypes { get; set; }

        [JsonPropertyName("eyecatcher")]
        public List<object> Eyecatcher { get; set; }

        [JsonPropertyName("contact")]
        public Contact Contact { get; set; }

        [JsonPropertyName("display_data")]
        public DisplayData DisplayData { get; set; }

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }

        [JsonPropertyName("files")]
        public List<object> Files { get; set; }

        [JsonPropertyName("exclusive")]
        public bool Exclusive { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("pdf_url_default")]
        public string PdfUrlDefault { get; set; }
    }

    public class Vermarktungsart
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class VerwaltungObjekt
    {
        [JsonPropertyName("verfuegbar_ab")]
        public string VerfuegbarAb { get; set; }

        [JsonPropertyName("vermietet")]
        public bool Vermietet { get; set; }

        [JsonPropertyName("objektadresse_freigeben")]
        public string ObjektadresseFreigeben { get; set; }
    }

    public class VerwaltungTechn
    {
        [JsonPropertyName("objektnr_intern")]
        public string ObjektnrIntern { get; set; }

        [JsonPropertyName("objektnr_extern")]
        public string ObjektnrExtern { get; set; }

        [JsonPropertyName("openimmo_obid")]
        public string OpenimmoObid { get; set; }
    }

    public class Waehrung
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class ZustandAngaben
    {
        [JsonPropertyName("energiepass")]
        public List<object> Energiepass { get; set; }

        [JsonPropertyName("alter")]
        public Alter Alter { get; set; }

        [JsonPropertyName("erschliessung")]
        public Erschliessung Erschliessung { get; set; }
    }



}