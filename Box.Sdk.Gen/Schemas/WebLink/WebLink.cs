using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Box.Sdk.Gen;
using Box.Sdk.Gen.Internal;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Schemas {
    public class WebLink : WebLinkMini {
        [JsonPropertyName("parent")]
        public FolderMini? Parent { get; init; }

        /// <summary>
        /// The description accompanying the web link. This is
        /// visible within the Box web application.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; init; }

        [JsonPropertyName("path_collection")]
        public WebLinkPathCollectionField? PathCollection { get; init; }

        /// <summary>
        /// When this file was created on Box’s servers.
        /// </summary>
        [JsonPropertyName("created_at")]
        public System.DateTimeOffset? CreatedAt { get; init; }

        /// <summary>
        /// When this file was last updated on the Box
        /// servers.
        /// </summary>
        [JsonPropertyName("modified_at")]
        public System.DateTimeOffset? ModifiedAt { get; init; }

        /// <summary>
        /// When this file was moved to the trash.
        /// </summary>
        [JsonPropertyName("trashed_at")]
        public System.DateTimeOffset? TrashedAt { get; init; }

        /// <summary>
        /// When this file will be permanently deleted.
        /// </summary>
        [JsonPropertyName("purged_at")]
        public System.DateTimeOffset? PurgedAt { get; init; }

        [JsonPropertyName("created_by")]
        public UserMini? CreatedBy { get; init; }

        [JsonPropertyName("modified_by")]
        public UserMini? ModifiedBy { get; init; }

        [JsonPropertyName("owned_by")]
        public UserMini? OwnedBy { get; init; }

        [JsonPropertyName("shared_link")]
        public WebLinkSharedLinkField? SharedLink { get; init; }

        /// <summary>
        /// Whether this item is deleted or not. Values include `active`,
        /// `trashed` if the file has been moved to the trash, and `deleted` if
        /// the file has been permanently deleted
        /// </summary>
        [JsonPropertyName("item_status")]
        [JsonConverter(typeof(StringEnumConverter<WebLinkItemStatusField>))]
        public StringEnum<WebLinkItemStatusField>? ItemStatus { get; init; }

        public WebLink(string id, WebLinkBaseTypeField type = WebLinkBaseTypeField.WebLink) : base(id, type) {
            
        }
        
        [JsonConstructorAttribute]
        internal WebLink(string id, StringEnum<WebLinkBaseTypeField> type) : base(id, type ?? new StringEnum<WebLinkBaseTypeField>(WebLinkBaseTypeField.WebLink)) {
            
        }
    }
}