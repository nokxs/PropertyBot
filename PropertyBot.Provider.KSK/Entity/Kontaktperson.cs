using System.Text.Json.Serialization;

namespace PropertyBot.Provider.KSK.Entity
{
    public class Kontaktperson    {
        [JsonPropertyName("email_feedback")]
        public string EmailFeedback { get; set; } 
    }
}