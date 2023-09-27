using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class GetFileByIdHeadersArg {
        /// <summary>
        /// Ensures an item is only returned if it has changed.
        /// 
        /// Pass in the item's last observed `etag` value
        /// into this header and the endpoint will fail
        /// with a `304 Not Modified` if the item has not
        /// changed since.
        /// </summary>
        public string? IfNoneMatch { get; set; } = default;

        /// <summary>
        /// The URL, and optional password, for the shared link of this item.
        /// 
        /// This header can be used to access items that have not been
        /// explicitly shared with a user.
        /// 
        /// Use the format `shared_link=[link]` or if a password is required then
        /// use `shared_link=[link]&shared_link_password=[password]`.
        /// 
        /// This header can be used on the file or folder shared, as well as on any files
        /// or folders nested within the item.
        /// </summary>
        public string? Boxapi { get; set; } = default;

        /// <summary>
        /// A header required to request specific `representations`
        /// of a file. Use this in combination with the `fields` query
        /// parameter to request a specific file representation.
        /// 
        /// The general format for these representations is
        /// `X-Rep-Hints: [...]` where `[...]` is one or many
        /// hints in the format `[fileType?query]`.
        /// 
        /// For example, to request a `png` representation in `32x32`
        /// as well as `64x64` pixel dimensions provide the following
        /// hints.
        /// 
        /// `x-rep-hints: [jpg?dimensions=32x32][jpg?dimensions=64x64]`
        /// 
        /// Additionally, a `text` representation is available for all
        /// document file types in Box using the `[extracted_text]`
        /// representation.
        /// 
        /// `x-rep-hints: [extracted_text]`
        /// </summary>
        public string? XRepHints { get; set; } = default;

        /// <summary>
        /// Extra headers that will be included in the HTTP request.
        /// </summary>
        public Dictionary<string, string?>? ExtraHeaders { get; set; } = new Dictionary<string, string?>() {  };

        public GetFileByIdHeadersArg() {
            
        }
    }
}