using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using System;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class UpdateClassificationRequestBodyDataStaticConfigField {
        /// <summary>
        /// Additional details for the classification.
        /// </summary>
        [JsonPropertyName("classification")]
        public UpdateClassificationRequestBodyDataStaticConfigClassificationField? Classification { get; set; } = default;

        public UpdateClassificationRequestBodyDataStaticConfigField() {
            
        }
    }
}