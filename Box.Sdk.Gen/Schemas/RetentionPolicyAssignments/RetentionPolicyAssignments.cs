using Box.Sdk.Gen;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Schemas {
    public class RetentionPolicyAssignments {
        [JsonInclude]
        [JsonPropertyName("_isnext_markerSet")]
        protected bool _isNextMarkerSet { get; set; }

        protected string? _nextMarker { get; set; }

        /// <summary>
        /// A list of retention policy assignments
        /// </summary>
        [JsonPropertyName("entries")]
        public IReadOnlyList<RetentionPolicyAssignment>? Entries { get; init; }

        /// <summary>
        /// The limit that was used for these entries. This will be the same as the
        /// `limit` query parameter unless that value exceeded the maximum value
        /// allowed. The maximum value varies by API.
        /// </summary>
        [JsonPropertyName("limit")]
        public long? Limit { get; init; }

        /// <summary>
        /// The marker for the start of the next page of results.
        /// </summary>
        [JsonPropertyName("next_marker")]
        public string? NextMarker { get => _nextMarker; init { _nextMarker = value; _isNextMarkerSet = true; } }

        public RetentionPolicyAssignments() {
            
        }
    }
}