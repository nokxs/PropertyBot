using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Sip    
    {
        [JsonIgnore]
        [JsonPropertyName("ort_vorschlag")]
        public string OrtVorschlag { get; set; }

        [JsonIgnore]
        [JsonPropertyName("pdf_url_default")]
        public string PdfUrlDefault { get; set; }

        [JsonIgnore]
        [JsonPropertyName("pdf_url_short")]
        public string PdfUrlShort { get; set; }

        [JsonIgnore]
        [JsonPropertyName("marketing_usage_object_types")]
        public List<string> MarketingUsageObjectTypes { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; } 

        [JsonPropertyName("modified")]
        public string Modified { get; set; }

        [JsonIgnore]
        [JsonPropertyName("is_deleted")]
        public string IsDeleted { get; set; }

        [JsonIgnore]
        [JsonPropertyName("auto_group_hash")]
        public string AutoGroupHash { get; set; }

        [JsonIgnore]
        [JsonPropertyName("imprint_is_active")]
        public bool ImprintIsActive { get; set; }

        [JsonIgnore]
        [JsonPropertyName("owner_blz")]
        public int OwnerBlz { get; set; }

        [JsonIgnore]
        [JsonPropertyName("broker")]
        public Broker Broker { get; set; }

        [JsonIgnore]
        [JsonPropertyName("rates")]
        public Rates Rates { get; set; }

        [JsonIgnore]
        [JsonPropertyName("rate")]
        public List<object> Rate { get; set; }

        [JsonIgnore]
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonIgnore]
        [JsonPropertyName("display_data")]
        public DisplayData DisplayData { get; set; } 

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }

        [JsonIgnore]
        [JsonPropertyName("files")]
        public List<object> Files { get; set; }

        [JsonIgnore]
        [JsonPropertyName("exclusive")]
        public bool Exclusive { get; set; }

        [JsonIgnore]
        [JsonPropertyName("qr_code_image_url")]
        public string QrCodeImageUrl { get; set; }

        [JsonIgnore]
        [JsonPropertyName("pdf_render_date_default")]
        public string PdfRenderDateDefault { get; set; } 
    }
}