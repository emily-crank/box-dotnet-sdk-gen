using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class CreateShieldInformationBarrierSegmentRestrictionRequestBodyRestrictedSegmentField {
        /// <summary>
        /// The ID reference of the restricted
        /// shield information barrier segment.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; } = default;

        /// <summary>
        /// The type of the restricted shield
        /// information barrier segment.
        /// </summary>
        [JsonPropertyName("type")]
        public CreateShieldInformationBarrierSegmentRestrictionRequestBodyRestrictedSegmentTypeField? Type { get; set; } = default;

        public CreateShieldInformationBarrierSegmentRestrictionRequestBodyRestrictedSegmentField() {
            
        }
    }
}