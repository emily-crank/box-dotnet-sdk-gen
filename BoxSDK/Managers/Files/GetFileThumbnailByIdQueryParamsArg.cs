using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class GetFileThumbnailByIdQueryParamsArg {
        /// <summary>
        /// The minimum height of the thumbnail
        /// </summary>
        public long? MinHeight { get; set; } = default;

        /// <summary>
        /// The minimum width of the thumbnail
        /// </summary>
        public long? MinWidth { get; set; } = default;

        /// <summary>
        /// The maximum height of the thumbnail
        /// </summary>
        public long? MaxHeight { get; set; } = default;

        /// <summary>
        /// The maximum width of the thumbnail
        /// </summary>
        public long? MaxWidth { get; set; } = default;

        public GetFileThumbnailByIdQueryParamsArg() {
            
        }
    }
}