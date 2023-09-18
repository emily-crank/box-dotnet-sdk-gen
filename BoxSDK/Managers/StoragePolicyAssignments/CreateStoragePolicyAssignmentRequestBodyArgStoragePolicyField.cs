using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class CreateStoragePolicyAssignmentRequestBodyArgStoragePolicyField {
        /// <summary>
        /// The type to assign.
        /// </summary>
        [JsonPropertyName("type")]
        public CreateStoragePolicyAssignmentRequestBodyArgStoragePolicyFieldTypeField Type { get; set; }

        /// <summary>
        /// The ID of the storage policy to assign.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        public CreateStoragePolicyAssignmentRequestBodyArgStoragePolicyField(CreateStoragePolicyAssignmentRequestBodyArgStoragePolicyFieldTypeField type, string id) {
            Type = type;
            Id = id;
        }
    }
}