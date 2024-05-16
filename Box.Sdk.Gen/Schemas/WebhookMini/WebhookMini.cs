using Unions;
using System.Text.Json.Serialization;

namespace Box.Sdk.Gen.Schemas {
    public class WebhookMini {
        /// <summary>
        /// The unique identifier for this webhook.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; } = default;

        /// <summary>
        /// `webhook`
        /// </summary>
        [JsonPropertyName("type")]
        public WebhookMiniTypeField? Type { get; set; } = default;

        /// <summary>
        /// The item that will trigger the webhook
        /// </summary>
        [JsonPropertyName("target")]
        public WebhookMiniTargetField? Target { get; set; } = default;

        public WebhookMini() {
            
        }
    }
}