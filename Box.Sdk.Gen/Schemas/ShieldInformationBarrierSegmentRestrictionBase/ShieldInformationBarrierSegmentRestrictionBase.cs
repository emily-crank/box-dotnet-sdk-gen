using Unions;
using System.Text.Json.Serialization;

namespace Box.Sdk.Gen.Schemas {
    public class ShieldInformationBarrierSegmentRestrictionBase {
        /// <summary>
        /// Shield information barrier segment restriction
        /// </summary>
        [JsonPropertyName("type")]
        public ShieldInformationBarrierSegmentRestrictionBaseTypeField? Type { get; set; } = default;

        /// <summary>
        /// The unique identifier for the
        /// shield information barrier segment restriction.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; } = default;

        public ShieldInformationBarrierSegmentRestrictionBase() {
            
        }
    }
}