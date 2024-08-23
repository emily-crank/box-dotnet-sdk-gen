using Box.Sdk.Gen;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Schemas {
    public class FileVersionLegalHolds {
        [JsonInclude]
        [JsonPropertyName("_isnext_markerSet")]
        protected bool _isNextMarkerSet { get; set; }

        [JsonInclude]
        [JsonPropertyName("_isprev_markerSet")]
        protected bool _isPrevMarkerSet { get; set; }

        protected string? _nextMarker { get; set; }

        protected string? _prevMarker { get; set; }

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

        /// <summary>
        /// The marker for the start of the previous page of results.
        /// </summary>
        [JsonPropertyName("prev_marker")]
        public string? PrevMarker { get => _prevMarker; init { _prevMarker = value; _isPrevMarkerSet = true; } }

        /// <summary>
        /// A list of file version legal holds
        /// </summary>
        [JsonPropertyName("entries")]
        public IReadOnlyList<FileVersionLegalHold>? Entries { get; init; }

        public FileVersionLegalHolds() {
            
        }
    }
}