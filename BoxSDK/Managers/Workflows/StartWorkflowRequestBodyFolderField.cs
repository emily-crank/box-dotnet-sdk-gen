using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using System;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class StartWorkflowRequestBodyFolderField {
        /// <summary>
        /// The type of the folder object
        /// </summary>
        [JsonPropertyName("type")]
        public StartWorkflowRequestBodyFolderTypeField? Type { get; set; } = default;

        /// <summary>
        /// The id of the folder
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; } = default;

        public StartWorkflowRequestBodyFolderField() {
            
        }
    }
}