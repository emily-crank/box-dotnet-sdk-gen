using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Box.Sdk.Gen;
using System.Text.Json.Serialization;
using Serializer;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Managers {
    public class UpdateFolderByIdRequestBody {
        /// <summary>
        /// The optional new name for this folder.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; init; }

        /// <summary>
        /// The optional description of this folder
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; init; }

        /// <summary>
        /// Specifies whether a folder should be synced to a
        /// user's device or not. This is used by Box Sync
        /// (discontinued) and is not used by Box Drive.
        /// </summary>
        [JsonPropertyName("sync_state")]
        [JsonConverter(typeof(StringEnumConverter<UpdateFolderByIdRequestBodySyncStateField>))]
        public StringEnum<UpdateFolderByIdRequestBodySyncStateField>? SyncState { get; init; }

        /// <summary>
        /// Specifies if users who are not the owner
        /// of the folder can invite new collaborators to the folder.
        /// </summary>
        [JsonPropertyName("can_non_owners_invite")]
        public bool? CanNonOwnersInvite { get; init; }

        /// <summary>
        /// The parent folder for this folder. Use this to move
        /// the folder or to restore it out of the trash.
        /// </summary>
        [JsonPropertyName("parent")]
        public UpdateFolderByIdRequestBodyParentField? Parent { get; init; }

        [JsonPropertyName("shared_link")]
        public UpdateFolderByIdRequestBodySharedLinkField? SharedLink { get; init; }

        [JsonPropertyName("folder_upload_email")]
        public UpdateFolderByIdRequestBodyFolderUploadEmailField? FolderUploadEmail { get; init; }

        /// <summary>
        /// The tags for this item. These tags are shown in
        /// the Box web app and mobile apps next to an item.
        /// 
        /// To add or remove a tag, retrieve the item's current tags,
        /// modify them, and then update this field.
        /// 
        /// There is a limit of 100 tags per item, and 10,000
        /// unique tags per enterprise.
        /// </summary>
        [JsonPropertyName("tags")]
        public IReadOnlyList<string>? Tags { get; init; }

        /// <summary>
        /// Specifies if new invites to this folder are restricted to users
        /// within the enterprise. This does not affect existing
        /// collaborations.
        /// </summary>
        [JsonPropertyName("is_collaboration_restricted_to_enterprise")]
        public bool? IsCollaborationRestrictedToEnterprise { get; init; }

        /// <summary>
        /// An array of collections to make this folder
        /// a member of. Currently
        /// we only support the `favorites` collection.
        /// 
        /// To get the ID for a collection, use the
        /// [List all collections][1] endpoint.
        /// 
        /// Passing an empty array `[]` or `null` will remove
        /// the folder from all collections.
        /// 
        /// [1]: e://get-collections
        /// </summary>
        [JsonPropertyName("collections")]
        public IReadOnlyList<UpdateFolderByIdRequestBodyCollectionsField>? Collections { get; init; }

        /// <summary>
        /// Restricts collaborators who are not the owner of
        /// this folder from viewing other collaborations on
        /// this folder.
        /// 
        /// It also restricts non-owners from inviting new
        /// collaborators.
        /// 
        /// When setting this field to `false`, it is required
        /// to also set `can_non_owners_invite_collaborators` to
        /// `false` if it has not already been set.
        /// </summary>
        [JsonPropertyName("can_non_owners_view_collaborators")]
        public bool? CanNonOwnersViewCollaborators { get; init; }

        public UpdateFolderByIdRequestBody() {
            
        }
    }
}