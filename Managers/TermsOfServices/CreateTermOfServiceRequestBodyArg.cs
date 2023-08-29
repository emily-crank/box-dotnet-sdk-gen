using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class CreateTermOfServiceRequestBodyArg {
        /// <summary>
        /// Whether this terms of service is active.
        /// </summary>
        [JsonPropertyName("status")]
        public CreateTermOfServiceRequestBodyArgStatusField Status { get; set; }

        /// <summary>
        /// The type of user to set the terms of
        /// service for.
        /// </summary>
        [JsonPropertyName("tos_type")]
        public CreateTermOfServiceRequestBodyArgTosTypeField? TosType { get; set; } = default;

        /// <summary>
        /// The terms of service text to display to users.
        /// 
        /// The text can be set to empty if the `status` is set to `disabled`.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        public CreateTermOfServiceRequestBodyArg(CreateTermOfServiceRequestBodyArgStatusField status, string text) {
            Status = status;
            Text = text;
        }
    }
}