using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Sip    {
        [JsonPropertyName("ort_vorschlag")]
        public string OrtVorschlag { get; set; } 

        [JsonPropertyName("pdf_url_default")]
        public string PdfUrlDefault { get; set; } 

        [JsonPropertyName("pdf_url_short")]
        public string PdfUrlShort { get; set; } 

        [JsonPropertyName("marketing_usage_object_types")]
        public List<string> MarketingUsageObjectTypes { get; set; } 

        [JsonPropertyName("created")]
        public string Created { get; set; } 

        [JsonPropertyName("modified")]
        public string Modified { get; set; } 

        [JsonPropertyName("is_deleted")]
        public string IsDeleted { get; set; } 

        [JsonPropertyName("auto_group_hash")]
        public string AutoGroupHash { get; set; } 

        [JsonPropertyName("imprint_is_active")]
        public bool ImprintIsActive { get; set; } 

        [JsonPropertyName("owner_blz")]
        public int OwnerBlz { get; set; } 

        [JsonPropertyName("broker")]
        public Broker Broker { get; set; } 

        [JsonPropertyName("rates")]
        public Rates Rates { get; set; } 

        [JsonPropertyName("rate")]
        public List<object> Rate { get; set; } 

        [JsonPropertyName("location")]
        public Location Location { get; set; } 

        [JsonPropertyName("display_data")]
        public DisplayData DisplayData { get; set; } 

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; } 

        [JsonPropertyName("files")]
        public List<object> Files { get; set; } 

        [JsonIgnore]
        [JsonPropertyName("exclusive")]
        public bool Exclusive { get; set; } 

        [JsonPropertyName("qr_code_image_url")]
        public string QrCodeImageUrl { get; set; } 

        [JsonPropertyName("pdf_render_date_default")]
        public string PdfRenderDateDefault { get; set; } 
    }
}