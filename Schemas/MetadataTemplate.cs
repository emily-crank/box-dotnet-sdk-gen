using System.IO;
using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Box.Schemas {
    public class MetadataTemplate {
        /// <summary>
        /// The ID of the metadata template.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; } = default;

        /// <summary>
        /// `metadata_template`
        /// </summary>
        [JsonPropertyName("type")]
        public MetadataTemplateTypeField Type { get; set; }

        /// <summary>
        /// The scope of the metadata template can either be `global` or
        /// `enterprise_*`. The `global` scope is used for templates that are
        /// available to any Box enterprise. The `enterprise_*` scope represents
        /// templates that have been created within a specific enterprise, where `*`
        /// will be the ID of that enterprise.
        /// </summary>
        [JsonPropertyName("scope")]
        public string? Scope { get; set; } = default;

        /// <summary>
        /// A unique identifier for the template. This identifier is unique across
        /// the `scope` of the enterprise to which the metadata template is being
        /// applied, yet is not necessarily unique across different enterprises.
        /// </summary>
        [JsonPropertyName("templateKey")]
        public string? TemplateKey { get; set; } = default;

        /// <summary>
        /// The display name of the template. This can be seen in the Box web app
        /// and mobile apps.
        /// </summary>
        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; } = default;

        /// <summary>
        /// Defines if this template is visible in the Box web app UI, or if
        /// it is purely intended for usage through the API.
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool? Hidden { get; set; } = default;

        /// <summary>
        /// An ordered list of template fields which are part of the template. Each
        /// field can be a regular text field, date field, number field, as well as a
        /// single or multi-select list.
        /// </summary>
        [JsonPropertyName("fields")]
        public IReadOnlyList<MetadataTemplateFieldsField>? Fields { get; set; } = default;

        /// <summary>
        /// Whether or not to include the metadata when a file or folder is copied.
        /// </summary>
        [JsonPropertyName("copyInstanceOnItemCopy")]
        public bool? CopyInstanceOnItemCopy { get; set; } = default;

        public MetadataTemplate(MetadataTemplateTypeField type) {
            Type = type;
        }
    }
}