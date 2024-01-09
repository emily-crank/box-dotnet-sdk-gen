using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class AddShareLinkToWebLinkRequestBody {
        /// <summary>
        /// The settings for the shared link to create on the web link.
        /// 
        /// Use an empty object (`{}`) to use the default settings for shared
        /// links.
        /// </summary>
        [JsonPropertyName("shared_link")]
        public AddShareLinkToWebLinkRequestBodySharedLinkField? SharedLink { get; set; } = default;

        public AddShareLinkToWebLinkRequestBody() {
            
        }
    }
}