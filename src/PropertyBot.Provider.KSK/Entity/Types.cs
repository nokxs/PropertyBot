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

        [JsonPropertyName("daten")]
        public string Daten { get; set; }
    }

    public class Attributes
    {
        [JsonPropertyName("KAUF")]
        public bool KAUF { get; set; }

        [JsonPropertyName("GARAGE")]
        public bool GARAGE { get; set; }

        [JsonPropertyName("FREIPLATZ")]
        public bool? FREIPLATZ { get; set; }

        [JsonPropertyName("CARPORT")]
        public bool? CARPORT { get; set; }

        [JsonPropertyName("SATTELDACH")]
        public bool SATTELDACH { get; set; }

        [JsonPropertyName("MASSIV")]
        public bool MASSIV { get; set; }

        [JsonPropertyName("HOLZ")]
        public bool? HOLZ { get; set; }

        [JsonPropertyName("EBK")]
        public bool EBK { get; set; }

        [JsonPropertyName("keller")]
        public string Keller { get; set; }

        [JsonPropertyName("zustand_art")]
        public string ZustandArt { get; set; }

        [JsonPropertyName("erschl_attr")]
        public string ErschlAttr { get; set; }

        [JsonPropertyName("alter_attr")]
        public string AlterAttr { get; set; }

        [JsonPropertyName("WOHNEN")]
        public bool WOHNEN { get; set; }

        [JsonPropertyName("GEWERBE")]
        public bool? GEWERBE { get; set; }

        [JsonPropertyName("haustyp")]
        public string Haustyp { get; set; }

        [JsonPropertyName("iso_land")]
        public string IsoLand { get; set; }

        [JsonPropertyName("iso_waehrung")]
        public string IsoWaehrung { get; set; }

        [JsonPropertyName("FENSTER")]
        public bool FENSTER { get; set; }

        [JsonPropertyName("DUSCHE")]
        public bool? DUSCHE { get; set; }

        [JsonPropertyName("WANNE")]
        public bool? WANNE { get; set; }

        [JsonPropertyName("FLIESEN")]
        public bool FLIESEN { get; set; }

        [JsonPropertyName("TEPPICH")]
        public bool TEPPICH { get; set; }

        [JsonPropertyName("PARKETT")]
        public bool? PARKETT { get; set; }

        [JsonPropertyName("DIELEN")]
        public bool? DIELEN { get; set; }

        [JsonPropertyName("LAMINAT")]
        public bool? LAMINAT { get; set; }

        [JsonPropertyName("ZENTRAL")]
        public bool ZENTRAL { get; set; }

        [JsonPropertyName("ETAGE")]
        public bool? ETAGE { get; set; }

        [JsonPropertyName("OFEN")]
        public bool? OFEN { get; set; }

        [JsonPropertyName("OEL")]
        public bool OEL { get; set; }

        [JsonPropertyName("GAS")]
        public bool? GAS { get; set; }

        [JsonPropertyName("ELEKTRO")]
        public bool? ELEKTRO { get; set; }

        [JsonPropertyName("FERN")]
        public bool? FERN { get; set; }
    }

    public class Attributes18
    {
        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("gruppe")]
        public string Gruppe { get; set; }
    }

    public class Ausstattung
    {
        [JsonPropertyName("ausstatt_kategorie")]
        public string AusstattKategorie { get; set; }

        [JsonPropertyName("bad")]
        public Bad Bad { get; set; }

        [JsonPropertyName("boden")]
        public Boden Boden { get; set; }

        [JsonPropertyName("heizungsart")]
        public Heizungsart Heizungsart { get; set; }

        [JsonPropertyName("befeuerung")]
        public Befeuerung Befeuerung { get; set; }

        [JsonPropertyName("stellplatzart")]
        public Stellplatzart Stellplatzart { get; set; }

        [JsonPropertyName("gartennutzung")]
        public bool Gartennutzung { get; set; }

        [JsonPropertyName("dachform")]
        public Dachform Dachform { get; set; }

        [JsonPropertyName("bauweise")]
        public Bauweise Bauweise { get; set; }

        [JsonPropertyName("gaestewc")]
        public bool? Gaestewc { get; set; }

        [JsonPropertyName("kabel_sat_tv")]
        public bool? KabelSatTv { get; set; }

        [JsonPropertyName("kueche")]
        public Kueche Kueche { get; set; }

        [JsonPropertyName("unterkellert")]
        public Unterkellert Unterkellert { get; set; }

        [JsonPropertyName("seniorengerecht")]
        public bool? Seniorengerecht { get; set; }

        [JsonPropertyName("abstellraum")]
        public bool? Abstellraum { get; set; }
    }

    public class Bad
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Bauweise
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Befeuerung
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Boden
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
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

    public class BuyResidentialHouse
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

    public class Dachform
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
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
        [JsonPropertyName("buy_residential_house")]
        public BuyResidentialHouse BuyResidentialHouse { get; set; }

        [JsonPropertyName("specials")]
        public List<string> Specials { get; set; }

        [JsonPropertyName("buy_business_others")]
        public BuyBusinessOthers BuyBusinessOthers { get; set; }
    }

    public class Embedded
    {
        [JsonPropertyName("estate")]
        public List<Estate> Estate { get; set; }
    }

    public class Energiepass
    {
        [JsonPropertyName("epart")]
        public string Epart { get; set; }

        [JsonPropertyName("gueltig_bis")]
        public string GueltigBis { get; set; }

        [JsonPropertyName("endenergiebedarf")]
        public string Endenergiebedarf { get; set; }

        [JsonPropertyName("primaerenergietraeger")]
        public string Primaerenergietraeger { get; set; }

        [JsonPropertyName("wertklasse")]
        public string Wertklasse { get; set; }

        [JsonPropertyName("baujahr")]
        public string Baujahr { get; set; }

        [JsonPropertyName("ausstelldatum")]
        public string Ausstelldatum { get; set; }

        [JsonPropertyName("jahrgang")]
        public string Jahrgang { get; set; }

        [JsonPropertyName("gebaeudeart")]
        public string Gebaeudeart { get; set; }

        [JsonPropertyName("epasstext")]
        public string Epasstext { get; set; }
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

        [JsonIgnore]
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

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class Eyecatcher
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Flaechen
    {
        [JsonPropertyName("wohnflaeche")]
        public double Wohnflaeche { get; set; }

        [JsonPropertyName("grundstuecksflaeche")]
        public int Grundstuecksflaeche { get; set; }

        [JsonPropertyName("anzahl_zimmer")]
        public double AnzahlZimmer { get; set; }

        [JsonPropertyName("anzahl_badezimmer")]
        public int AnzahlBadezimmer { get; set; }

        [JsonPropertyName("anzahl_balkone")]
        public int AnzahlBalkone { get; set; }

        [JsonPropertyName("anzahl_terrassen")]
        public int AnzahlTerrassen { get; set; }

        [JsonPropertyName("anzahl_stellplaetze")]
        public int AnzahlStellplaetze { get; set; }

        [JsonPropertyName("nutzflaeche")]
        public double? Nutzflaeche { get; set; }

        [JsonPropertyName("anzahl_sep_wc")]
        public int? AnzahlSepWc { get; set; }

        [JsonPropertyName("einliegerwohnung")]
        public bool? Einliegerwohnung { get; set; }

        [JsonPropertyName("gesamtflaeche")]
        public double? Gesamtflaeche { get; set; }

        [JsonPropertyName("anzahl_schlafzimmer")]
        public int? AnzahlSchlafzimmer { get; set; }

        [JsonPropertyName("vermietbare_flaeche")]
        public double? VermietbareFlaeche { get; set; }

        [JsonPropertyName("anzahl_wohneinheiten")]
        public int? AnzahlWohneinheiten { get; set; }

        [JsonPropertyName("anzahl_gewerbeeinheiten")]
        public int? AnzahlGewerbeeinheiten { get; set; }
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

        [JsonPropertyName("anzahl_etagen")]
        public int AnzahlEtagen { get; set; }

        [JsonPropertyName("bundesland")]
        public string Bundesland { get; set; }

        [JsonPropertyName("regionaler_zusatz")]
        public string RegionalerZusatz { get; set; }

        [JsonPropertyName("land")]
        public Land Land { get; set; }
    }

    public class Haus
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Heizungsart
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

        [JsonPropertyName("90090159")]
        public bool? _90090159 { get; set; }

        [JsonPropertyName("60250010")]
        public bool? _60250010 { get; set; }

        [JsonPropertyName("60450050")]
        public bool? _60450050 { get; set; }
    }

    public class Kontaktperson
    {
        [JsonPropertyName("email_feedback")]
        public string EmailFeedback { get; set; }
    }

    public class Kueche
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
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
        [JsonPropertyName("haus")]
        public Haus Haus { get; set; }

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

        [JsonIgnore]
        [JsonPropertyName("mieteinnahmen_ist")]
        public int? MieteinnahmenIst { get; set; }
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
        public List<Eyecatcher> Eyecatcher { get; set; }

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

    public class Stellplatzart
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Unterkellert
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class UserDefinedAnyfield
    {
        [JsonPropertyName("exklusiv_objekt")]
        public string ExklusivObjekt { get; set; }
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

        [JsonPropertyName("objektadresse_freigeben")]
        public string ObjektadresseFreigeben { get; set; }

        [JsonPropertyName("user_defined_anyfield")]
        public List<UserDefinedAnyfield> UserDefinedAnyfield { get; set; }

        [JsonPropertyName("vermietet")]
        public bool? Vermietet { get; set; }
    }

    public class VerwaltungTechn
    {
        [JsonPropertyName("objektnr_intern")]
        public string ObjektnrIntern { get; set; }

        [JsonPropertyName("objektnr_extern")]
        public string ObjektnrExtern { get; set; }

        [JsonPropertyName("openimmo_obid")]
        public string OpenimmoObid { get; set; }

        [JsonPropertyName("gruppen_kennung")]
        public string GruppenKennung { get; set; }
    }

    public class Waehrung
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Zustand
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class ZustandAngaben
    {
        [JsonIgnore]
        [JsonPropertyName("energiepass")]
        public Energiepass Energiepass { get; set; }

        [JsonPropertyName("baujahr")]
        public int Baujahr { get; set; }

        [JsonPropertyName("zustand")]
        public Zustand Zustand { get; set; }

        [JsonPropertyName("erschliessung")]
        public Erschliessung Erschliessung { get; set; }

        [JsonPropertyName("letztemodernisierung")]
        public string Letztemodernisierung { get; set; }

        [JsonPropertyName("alter")]
        public Alter Alter { get; set; }
    }
}