using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class UpdateFolderWatermarkRequestBody {
        /// <summary>
        /// The watermark to imprint on the folder
        /// </summary>
        [JsonPropertyName("watermark")]
        public UpdateFolderWatermarkRequestBodyWatermarkField Watermark { get; set; }

        public UpdateFolderWatermarkRequestBody(UpdateFolderWatermarkRequestBodyWatermarkField watermark) {
            Watermark = watermark;
        }
    }
}