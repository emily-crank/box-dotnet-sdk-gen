using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class UpdateWebLinkRemoveSharedLinkQueryParamsArg {
        /// <summary>
        /// Explicitly request the `shared_link` fields
        /// to be returned for this item.
        /// </summary>
        public string Fields { get; set; }

        public UpdateWebLinkRemoveSharedLinkQueryParamsArg(string fields) {
            Fields = fields;
        }
    }
}