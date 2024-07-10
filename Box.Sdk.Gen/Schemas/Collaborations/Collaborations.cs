using Box.Sdk.Gen;
using System.Text.Json.Serialization;
using Box.Sdk.Gen.Internal;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Schemas {
    public class Collaborations {
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
        public string? NextMarker { get; init; }

        /// <summary>
        /// The marker for the start of the previous page of results.
        /// </summary>
        [JsonPropertyName("prev_marker")]
        public string? PrevMarker { get; init; }

        /// <summary>
        /// One greater than the offset of the last entry in the entire collection.
        /// The total number of entries in the collection may be less than
        /// `total_count`.
        /// 
        /// This field is only returned for calls that use offset-based pagination.
        /// For marker-based paginated APIs, this field will be omitted.
        /// </summary>
        [JsonPropertyName("total_count")]
        public long? TotalCount { get; init; }

        /// <summary>
        /// The 0-based offset of the first entry in this set. This will be the same
        /// as the `offset` query parameter.
        /// 
        /// This field is only returned for calls that use offset-based pagination.
        /// For marker-based paginated APIs, this field will be omitted.
        /// </summary>
        [JsonPropertyName("offset")]
        public long? Offset { get; init; }

        /// <summary>
        /// The order by which items are returned.
        /// 
        /// This field is only returned for calls that use offset-based pagination.
        /// For marker-based paginated APIs, this field will be omitted.
        /// </summary>
        [JsonPropertyName("order")]
        public IReadOnlyList<CollaborationsOrderField>? Order { get; init; }

        /// <summary>
        /// A list of collaborations
        /// </summary>
        [JsonPropertyName("entries")]
        public IReadOnlyList<Collaboration>? Entries { get; init; }

        public Collaborations() {
            
        }
    }
}