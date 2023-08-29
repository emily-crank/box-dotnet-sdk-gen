using System.IO;
using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Box.Schemas {
    public class ClassificationTemplateFieldsFieldOptionsField {
        /// <summary>
        /// The unique ID of this classification.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; } = default;

        /// <summary>
        /// The display name and key for this classification.
        /// </summary>
        [JsonPropertyName("key")]
        public string? Key { get; set; } = default;

        /// <summary>
        /// Additional information about the classification.
        /// </summary>
        [JsonPropertyName("staticConfig")]
        public ClassificationTemplateFieldsFieldOptionsFieldStaticConfigField? StaticConfig { get; set; } = default;

        public ClassificationTemplateFieldsFieldOptionsField() {
            
        }
    }
}